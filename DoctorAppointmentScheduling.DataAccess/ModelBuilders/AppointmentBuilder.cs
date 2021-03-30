using DoctorAppointmentScheduling.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.DataAccess.ModelBuilders
{
    public class AppointmentBuilder
    {
        public static void BuildAppointment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }
    }
}
