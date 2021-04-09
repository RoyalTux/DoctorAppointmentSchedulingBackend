using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class SignInViewModel
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
    }
}
