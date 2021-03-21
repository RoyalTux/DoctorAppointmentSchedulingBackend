using DoctorAppointmentScheduling.Domain.Enums;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public Rating Rating { get; set; }

        public string Description { get; set; }
    }
}
