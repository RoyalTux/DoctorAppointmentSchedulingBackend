using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Review : IEntity
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
