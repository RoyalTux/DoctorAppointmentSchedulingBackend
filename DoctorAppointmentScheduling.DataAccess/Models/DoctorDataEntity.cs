using DoctorAppointmentScheduling.DataAccess.Enums;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.DataAccess.Models
{
    public class DoctorDataEntity : UserDataEntity
    {
        public int Id { get; set; }

        public int ExperienceYears { get; set; }

        public List<SpecialzationDataEntity> Specializations = new List<SpecialzationDataEntity>();

        public Rating? Rating { get; set; }
    }
}
