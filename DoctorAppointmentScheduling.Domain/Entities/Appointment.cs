using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
