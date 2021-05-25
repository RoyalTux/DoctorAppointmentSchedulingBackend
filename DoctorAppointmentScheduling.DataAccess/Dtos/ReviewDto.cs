using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class ReviewDto : IEntity<int>
    {
        public int Id { get; set; }

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }

        public Rating Rating { get; set; }

        public string Description { get; set; }
    }
}
