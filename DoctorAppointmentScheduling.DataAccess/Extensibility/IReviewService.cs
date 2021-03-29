using DoctorAppointmentScheduling.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.DataAccess.Extensibility
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviews();

        Task<Review> GetReviewById(int id);

        Task<Review> AddReview(Patient entity);

        Task<Review> UpdateReview(Patient entity);

        Task<Review> DeleteReview(int id);
    }
}
