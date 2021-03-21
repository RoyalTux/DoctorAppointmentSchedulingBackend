using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Models
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Bio { get; set; }

        public string Phone { get; set; }

        public List<Booking> Appointments = new List<Booking>();
    }
}
