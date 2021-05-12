using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class SignUpViewModel
    {
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

        [Display(Name = "Is Doctor")]
        public bool IsDoctor { get; set; }
    }
}
