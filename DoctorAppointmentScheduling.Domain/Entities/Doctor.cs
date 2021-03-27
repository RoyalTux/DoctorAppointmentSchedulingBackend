using DoctorAppointmentScheduling.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Entities
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
