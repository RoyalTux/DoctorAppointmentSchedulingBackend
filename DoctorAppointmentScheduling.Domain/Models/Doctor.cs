using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Bio { get; set; }

        public int ExperienceYears { get; set; }

        public string DoctorType { get; set; }

        public double? Payment { get; set; }

        public double? Rating { get; set; }

        public string Phone { get; set; }

        public List<Booking> Appointments = new List<Booking>();
    }
}
