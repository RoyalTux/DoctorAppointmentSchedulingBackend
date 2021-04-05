using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class AppointmentDto : IEntity
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
