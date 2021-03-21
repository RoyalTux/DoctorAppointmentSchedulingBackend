using System.Collections.Generic;

namespace DoctorAppointmentScheduling.DataAccess.Models
{
    public class UserDataEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Bio { get; set; }

        public string Phone { get; set; }

        public List<AppointmentDataEntity> Appointments = new List<AppointmentDataEntity>();
    }
}
