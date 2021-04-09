using DoctorAppointmentScheduling.DataAccess.Dtos;
using DoctorAppointmentScheduling.DataAccess.ModelBuilders;
using DoctorAppointmentScheduling.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DoctorAppointmentScheduling.DataAccess.Context
{
    public class ClinicDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointmentDto> Bookings { get; set; }

        public virtual DbSet<DoctorDto> Doctors { get; set; }

        public virtual DbSet<PatientDto> Patients { get; set; }

        public virtual DbSet<ReviewDto> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppointmentBuilder.BuildAppointment(modelBuilder);
            DoctorBuilder.BuildDoctor(modelBuilder);
            ReviewBuilder.BuildReview(modelBuilder);
            PatientBuilder.BuildPatient(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
