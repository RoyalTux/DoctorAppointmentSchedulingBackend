﻿using System.ComponentModel.DataAnnotations;

namespace DoctorAppointmentScheduling.Domain.Entities
{
    public class Patient : User, IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Address { get; set; }
    }
}