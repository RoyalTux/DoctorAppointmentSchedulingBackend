using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50, MinimumLength = 1)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string PasswordConfirm { get; set; }

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
