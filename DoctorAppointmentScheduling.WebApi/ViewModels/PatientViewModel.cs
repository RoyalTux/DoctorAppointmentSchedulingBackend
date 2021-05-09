using DoctorAppointmentScheduling.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class PatientViewModel : BaseUserViewModel, IEntity<Guid>
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
    }
}
