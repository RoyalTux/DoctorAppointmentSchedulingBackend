using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class PatientDto : BaseUserDto, IEntity<Guid>
    {
        public Guid Id { get; set; }

        public string Address { get; set; }
    }
}
