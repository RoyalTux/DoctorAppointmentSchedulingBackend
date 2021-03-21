using DoctorAppointmentScheduling.Domain.Models;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IReviewRepository
    {
        int Add(Review newReview);

        IEnumerable<Review> Get(int DoctorId);

        void Delete(int Id);

        void Update(Review newReview);
    }
}
