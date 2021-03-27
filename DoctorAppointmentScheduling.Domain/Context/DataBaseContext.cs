using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.Domain.Extensibility.Entities;
using DoctorAppointmentScheduling.Domain.ModelBuilders;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.Domain
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext() { }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Bookings { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

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
