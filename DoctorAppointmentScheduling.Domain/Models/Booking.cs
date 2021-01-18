using System;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int DoctorId { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
