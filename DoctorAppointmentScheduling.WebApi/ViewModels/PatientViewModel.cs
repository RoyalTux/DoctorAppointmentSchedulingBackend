using DoctorAppointmentScheduling.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class PatientViewModel : BaseUserViewModel, IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
    }
}
