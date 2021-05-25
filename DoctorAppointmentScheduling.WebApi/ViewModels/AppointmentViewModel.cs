using DoctorAppointmentScheduling.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System;

namespace DoctorAppointmentScheduling.WebAPi.ViewModels
{
    public class AppointmentViewModel : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
    }
}
