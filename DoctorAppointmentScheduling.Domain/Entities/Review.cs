using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Review : IEntity<int>
    {
        public int Id { get; set; }

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }

        public Rating Rating { get; set; }

        public string Description { get; set; }
    }
}
