using System;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Extensibility.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
    }
}
