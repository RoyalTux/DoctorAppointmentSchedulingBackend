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

        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BookingBuilder.BuildBooking(modelBuilder);
            DoctorBuilder.BuildDoctor(modelBuilder);
            ReviewBuilder.BuildReview(modelBuilder);
            UserBuilder.BuildUser(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
