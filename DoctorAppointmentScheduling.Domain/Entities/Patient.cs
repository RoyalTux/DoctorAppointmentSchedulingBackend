using DoctorAppointmentScheduling.Domain.Interfaces;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Patient : User, IEntity
    {
        public int Id { get; set; }

        public string Address { get; set; }
    }
}
