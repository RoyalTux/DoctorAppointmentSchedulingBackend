using DoctorAppointmentScheduling.Domain.Extensibility.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Extensibility.Entities
{
    public class Doctor : User, IEntity
    {
        public int Id { get; set; }

        [Required]
        public int ExperienceYears { get; set; }

        [Required]
        public List<Specialzation> Specializations = new List<Specialzation>();

        [Required]
        public Rating? Rating { get; set; }
    }
}
