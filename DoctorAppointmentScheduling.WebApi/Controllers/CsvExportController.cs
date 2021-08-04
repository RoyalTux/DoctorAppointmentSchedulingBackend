using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Services;
using DoctorAppointmentScheduling.WebAPi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvExportController
    {
        private readonly DoctorService _doctorService;
        private readonly IMapper _mapper;

        public CsvExportController(DoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet("Doctors")]
        public ActionResult<string> Get()
        {
            DateTime dateTime = DateTime.Now;
            string csvFileName = "Clinic doctors list_" + dateTime.ToString("dddd, dd MMMM yyyy HH mm ss");
            Task<List<Doctor>> doctorsListTask = Task.Run(() => _doctorService.GetAll());
            List<Doctor> domainDoctorsList = doctorsListTask.Result;
            List<DoctorViewModel> doctorsList = _mapper.Map<List<DoctorViewModel>>(domainDoctorsList);

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

            try
            {
                Task exportDoctrorsListToCsvTask = new Task(() => ExportCsv(doctorsList, csvFileName));
                exportDoctrorsListToCsvTask.Start();
            }
            catch
            {
                cancelTokenSource.Cancel();

                return "CSV not saved!";
            }
            finally
            {
                cancelTokenSource.Dispose();
            }
 
            return "CSV successfully saved!";
        }

        public static void ExportCsv<T>(List<T> genericList, string fileName)
        {
            var sb = new StringBuilder();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var finalPath = Path.Combine(basePath, fileName + ".csv");
            var header = "";
            var info = typeof(T).GetProperties();

            if (!File.Exists(finalPath))
            {
                var file = File.Create(finalPath);
                file.Close();

                foreach (var prop in typeof(T).GetProperties())
                {
                    header += prop.Name + "; ";
                }

                header = header.Substring(0, header.Length - 2);
                sb.AppendLine(header);

                TextWriter sw = new StreamWriter(finalPath, true);

                sw.Write(sb.ToString());
                sw.Close();
            }
            foreach (var obj in genericList)
            {
                sb = new StringBuilder();
                var line = "";

                foreach (var prop in info)
                {
                    line += prop.GetValue(obj, null) + "; ";
                }

                line = line.Substring(0, line.Length - 2);
                sb.AppendLine(line);

                TextWriter sw = new StreamWriter(finalPath, true);

                sw.Write(sb.ToString());
                sw.Close();
            }
        }
    }
}


