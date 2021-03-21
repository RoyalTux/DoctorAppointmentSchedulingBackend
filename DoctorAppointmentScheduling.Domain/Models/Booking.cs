using System;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
