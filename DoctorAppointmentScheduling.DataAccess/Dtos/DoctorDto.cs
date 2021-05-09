using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class DoctorDto : BaseUserDto, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public int ExperienceYears { get; set; }

        public Rating? Rating { get; set; }
    }
}
