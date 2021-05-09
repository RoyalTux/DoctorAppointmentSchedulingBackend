using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Doctor : BaseUser, IEntity<Guid>
    {
        // public int Id { get; set; }

        public int ExperienceYears { get; set; }

        public Rating? Rating { get; set; }
    }
}
