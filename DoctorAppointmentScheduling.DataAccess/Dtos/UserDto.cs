using System.Collections.Generic;

namespace DoctorAppointmentScheduling.DataAccess.Dtos
{
    public class UserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Bio { get; set; }

        public string PhoneNumber { get; set; }

        public List<AppointmentDto> Appointments = new List<AppointmentDto>();
    }
}
