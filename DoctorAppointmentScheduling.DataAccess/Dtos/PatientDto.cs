using DoctorAppointmentScheduling.Domain.Interfaces;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class PatientDto : UserDto, IEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }
    }
}
