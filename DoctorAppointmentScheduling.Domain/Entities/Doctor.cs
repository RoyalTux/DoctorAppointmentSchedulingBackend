using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Doctor : User, IEntity
    {
        public int Id { get; set; }

        public int ExperienceYears { get; set; }

        public Rating? Rating { get; set; }
    }
}
