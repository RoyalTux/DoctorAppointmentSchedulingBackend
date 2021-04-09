using DoctorAppointmentScheduling.Domain.Interfaces;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Patient : BaseUser, IEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }
    }
}
