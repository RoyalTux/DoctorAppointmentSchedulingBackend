using DoctorAppointmentScheduling.DataAccess.Enums;

namespace DoctorAppointmentScheduling.DataAccess.Models
{
    public class ReviewDataEntity
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public Rating Rating { get; set; }

        public string Description { get; set; }
    }
}
