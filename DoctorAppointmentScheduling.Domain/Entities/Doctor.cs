using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Doctor : User, IEntity
    {
        public int Id { get; set; }

        [Required]
        public int ExperienceYears { get; set; }

        [Required]
        public Rating? Rating { get; set; }
    }
}
