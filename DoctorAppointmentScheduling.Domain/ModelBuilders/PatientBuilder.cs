using DoctorAppointmentScheduling.Domain.Extensibility.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.Domain.ModelBuilders
{
    public class PatientBuilder
    {
        public static void BuildPatient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany(e => e.Appointments);
            });
        }
    }
}
