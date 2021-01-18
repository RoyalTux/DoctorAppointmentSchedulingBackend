using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public List<Booking> Appointments = new List<Booking>();
    }
}
