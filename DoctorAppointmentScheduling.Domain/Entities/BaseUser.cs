using DoctorAppointmentScheduling.Domain.Entities.Auth;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class BaseUser : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        // public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Bio { get; set; }

        public List<Appointment> Appointments = new List<Appointment>();
    }
}
