using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class ReviewViewModel : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
    }
}
