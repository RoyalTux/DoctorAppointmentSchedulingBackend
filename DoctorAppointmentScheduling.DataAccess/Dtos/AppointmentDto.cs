using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class AppointmentDto : IEntity<int>
    {
        public int Id { get; set; }

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
