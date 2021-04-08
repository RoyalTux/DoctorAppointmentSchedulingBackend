using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Bio { get; set; }

        public List<Appointment> Appointments = new List<Appointment>();
    }
}
