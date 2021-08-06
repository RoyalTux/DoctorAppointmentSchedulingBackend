using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Services;
using DoctorAppointmentScheduling.WebAPi.Extensions;
using DoctorAppointmentScheduling.WebAPi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("api/[controller]")]
    public class CsvExportController
    {
        private readonly DoctorService _doctorService;
        private readonly PatientService _patientService;
        private readonly IMapper _mapper;

        public CsvExportController(DoctorService doctorService, PatientService patientService, IMapper mapper)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet("Doctors/{csvFilesNumber}")]
        public ActionResult<string> ExportDoctors(int csvFilesNumber)
        {
            DateTime dateTime = DateTime.Now;
            string csvFolderName = "Clinic doctors_" + dateTime.ToString("dddd, dd MMMM yyyy HH mm ss");
            string finalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, csvFolderName);
            Task<List<Doctor>> doctorsListTask = Task.Run(() => _doctorService.GetAll());
            List<Doctor> domainDoctorsList = doctorsListTask.Result;
            List<DoctorViewModel> doctorList = _mapper.Map<List<DoctorViewModel>>(domainDoctorsList);

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }

            try
            {
                for (int i = 0; i < csvFilesNumber; i++)
                {
                    string csvFileName = "Clinic doctors list_" + dateTime.ToString("dddd, dd MMMM yyyy HH mm ss") + "_" + (i + 1);
                    CsvExporter<DoctorViewModel> csvExporter = new CsvExporter<DoctorViewModel>(doctorList, csvFileName, finalPath);
                    Thread csvExporterThread = new Thread(new ThreadStart(csvExporter.ExportCsv));

                    csvExporterThread.Start();
                    csvExporterThread.Join();
                }
            }
            catch
            {
                return "CSV file not saved!";
            }

            return "CSV files successfully saved!";
        }

        [HttpGet("Patients/{csvFilesNumber}")]
        public ActionResult<string> ExportPatients(int csvFilesNumber)
        {
            DateTime dateTime = DateTime.Now;
            string csvFolderName = "Clinic patients_" + dateTime.ToString("dddd, dd MMMM yyyy HH mm ss");
            string finalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, csvFolderName);
            Task<List<Patient>> patientsListTask = Task.Run(() => _patientService.GetAll());
            List<Patient> domainPatientsList = patientsListTask.Result;
            List<PatientViewModel> patientsList = _mapper.Map<List<PatientViewModel>>(domainPatientsList);

            if (!Directory.Exists(finalPath))
            {
                Directory.CreateDirectory(finalPath);
            }

            try
            {
                for (int i = 0; i < csvFilesNumber; i++)
                {
                    string csvFileName = "Clinic patients list_" + dateTime.ToString("dddd, dd MMMM yyyy HH mm ss") + "_" + (i + 1);
                    CsvExporter<PatientViewModel> csvExporter = new CsvExporter<PatientViewModel>(patientsList, csvFileName, finalPath);
                    Thread csvExporterThread = new Thread(new ThreadStart(csvExporter.ExportCsv));

                    csvExporterThread.Start();
                    csvExporterThread.Join();
                }
            }
            catch
            {
                return "CSV file not saved!";
            }

            return "CSV files successfully saved!";
        }
    }
}


