using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Appointment : IEntity<int>
    {
        public int Id { get; set; }

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
