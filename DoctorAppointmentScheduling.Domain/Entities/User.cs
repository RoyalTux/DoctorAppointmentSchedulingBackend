using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class User
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Country { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Bio { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string Phone { get; set; }

        [Required]
        public List<Appointment> Appointments = new List<Appointment>();
    }
}
