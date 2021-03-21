using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.DataAccess.ModelBuilders;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointmentDataEntity> Bookings { get; set; }

        public virtual DbSet<DoctorDataEntity> Doctors { get; set; }

        public virtual DbSet<PatientDataEntity> Patients { get; set; }

        public virtual DbSet<ReviewDataEntity> Reviews { get; set; }

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
