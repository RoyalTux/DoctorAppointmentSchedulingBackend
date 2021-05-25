using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class BaseUserViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

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
        public string PhoneNumber { get; set; }

        [Required]
        public List<AppointmentViewModel> Appointments = new List<AppointmentViewModel>();
    }
}
