using DoctorAppointmentScheduling.Domain.Interfaces;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class PatientDto : BaseUserDto, IEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }
    }
}
