using DoctorAppointmentScheduling.Domain.Interfaces;
using System;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Patient : BaseUser, IEntity<Guid>
    {
        // public int Id { get; set; }

        public string Address { get; set; }
    }
}
