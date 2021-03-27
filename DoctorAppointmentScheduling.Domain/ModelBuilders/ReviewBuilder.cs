using DoctorAppointmentScheduling.Domain.Extensibility.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.Domain.ModelBuilders
{
    public class ReviewBuilder
    {
        public static void BuildReview(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Review");

                entity.Property(e => e.Rating).HasMaxLength(5);

                entity.Property(e => e.PatientId).HasColumnName("patientId");

                entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            });
        }
    }
}
