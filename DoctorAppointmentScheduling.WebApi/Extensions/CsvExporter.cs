using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace DoctorAppointmentScheduling.WebAPi.Extensions
{
    public class CsvExporter<T>
    {
        private List<T> _genericList;

        private string _fileName;

        private string _basePath;

        public CsvExporter(List<T> genericList, string fileName, string basePath)
        {
            _genericList = genericList;
            _fileName = fileName;
            _basePath = basePath;
        }

        public void ExportCsv()
        {
            var sb = new StringBuilder();
            var finalPath = Path.Combine(_basePath, _fileName + ".csv");
            var header = "";
            var info = typeof(T).GetProperties();
            int thread_counter = 3;
            Semaphore semaphore = new Semaphore(thread_counter, thread_counter);

            while (thread_counter > 0)
            {
                semaphore.WaitOne();

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
                foreach (var obj in _genericList)
                {
                    sb = new StringBuilder();
                    var line = "";

                    foreach (var prop in info)
                    {
                        line += prop.GetValue(obj, null) + "; ";
                    }

                    line = line.Substring(0, line.Length - 2);
                    line += Thread.CurrentThread.ManagedThreadId + ";";
                    sb.AppendLine(line);

                    TextWriter sw = new StreamWriter(finalPath, true);

                    sw.Write(sb.ToString());
                    sw.Close();
                }

                semaphore.Release();

                thread_counter--;
            }

            semaphore.Dispose();
        }
    }
}
