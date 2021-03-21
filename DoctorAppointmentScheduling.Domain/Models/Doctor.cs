using DoctorAppointmentScheduling.Domain.Enums;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class Doctor : User
    {
        public int Id { get; set; }

        public int ExperienceYears { get; set; }

        public List<CostOfServices> CostOfServices = new List<CostOfServices>();

        public Rating? Rating { get; set; }
    }
}
