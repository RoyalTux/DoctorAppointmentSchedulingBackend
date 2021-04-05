using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class DoctorDto : UserDto, IEntity
    {
        public int Id { get; set; }

        public int ExperienceYears { get; set; }

        public Rating? Rating { get; set; }
    }
}
