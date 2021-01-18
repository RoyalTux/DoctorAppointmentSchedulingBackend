using DoctorAppointmentScheduling.Domain.Models;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IReviewRepository
    {
        int Add(Review newReview);

        IEnumerable<Review> GetReviews(int DoctorId);

        void Delete(int Id);

        void Update(Review newReview);
    }
}
