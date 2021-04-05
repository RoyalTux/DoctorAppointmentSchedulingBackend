using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class ReviewDto : IEntity
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public Rating Rating { get; set; }

        public string Description { get; set; }
    }
}
