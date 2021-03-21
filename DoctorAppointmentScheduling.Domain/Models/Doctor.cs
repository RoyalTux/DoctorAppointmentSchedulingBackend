using DoctorAppointmentScheduling.Domain.Enums;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class Doctor : User
    {
        public int Id { get; set; }

        public int ExperienceYears { get; set; }

        public List<Specialzation> Specializations = new List<Specialzation>();

        public Rating? Rating { get; set; }
    }
}
