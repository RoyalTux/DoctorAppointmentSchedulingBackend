using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class DoctorViewModel : BaseUserViewModel, IEntity<Guid>
    {
        public Guid Id { get; set; }

        [Required]
        public int ExperienceYears { get; set; }

        public Rating? Rating { get; set; }
    }
}
