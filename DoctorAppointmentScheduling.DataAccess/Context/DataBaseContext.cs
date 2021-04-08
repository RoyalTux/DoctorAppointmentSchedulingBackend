using DoctorAppointmentScheduling.DataAccess.Dtos;
using DoctorAppointmentScheduling.DataAccess.ModelBuilders;
using DoctorAppointmentScheduling.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.DataAccess.Context
{
    public class DataBaseContext : IdentityDbContext<User>
    {
        public DataBaseContext() { }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
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
