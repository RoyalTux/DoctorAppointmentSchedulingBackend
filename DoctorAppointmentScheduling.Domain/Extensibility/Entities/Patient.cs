using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Extensibility.Entities
{
    public class Patient : User, IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Address { get; set; }
    }
}
