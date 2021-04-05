using DoctorAppointmentScheduling.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.DataAccess.ModelBuilders
{
    public class PatientBuilder
    {
        public static void BuildPatient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientDto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany(e => e.Appointments);
            });
        }
    }
}
