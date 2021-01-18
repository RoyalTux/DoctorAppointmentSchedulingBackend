using DoctorAppointmentScheduling.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.DataAccess.ModelBuilders
{
    public class ReviewBuilder
    {
        public static void BuildReview(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.ReviewId);
                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("Review");

                entity.Property(e => e.Rating).HasMaxLength(5);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });
        }
    }
}
