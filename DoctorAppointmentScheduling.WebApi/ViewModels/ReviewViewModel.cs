using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class ReviewViewModel : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
    }
}
