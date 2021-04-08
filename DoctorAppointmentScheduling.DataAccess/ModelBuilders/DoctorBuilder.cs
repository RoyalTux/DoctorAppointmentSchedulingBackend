using DoctorAppointmentScheduling.DataAccess.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.DataAccess.ModelBuilders
{
    public class DoctorBuilder
    {
        public static void BuildDoctor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorDto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasMaxLength(300);

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

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasMany(e => e.Appointments);
            });
        }
    }
}
