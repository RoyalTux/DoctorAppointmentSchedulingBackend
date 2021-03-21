using System.Collections.Generic;
using System.Linq;
using DoctorAppointmentScheduling.DataAccess.Enums;
using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataBaseContext _context;

        public ReviewRepository(DataBaseContext context)
        {
            _context = context;
        }

        public int Add(Review newReview)
        {
            var entity = new ReviewDataEntity
            {
                DoctorId = newReview.DoctorId,
                PatientId = newReview.PatientId,
                Rating = (Rating)newReview.Rating,
                Description = newReview.Description
            };

            _context.Reviews.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Delete(int Id)
        {
            var entity = _context.Reviews.Find(Id);

            _context.Reviews.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Review> Get(int DoctorId)
        {
            var entities = _context.Reviews
                .Where(r => r.DoctorId == DoctorId);

            return entities.Select(review => new Review
            {
                Id = review.Id,
                Rating = (Domain.Enums.Rating)review.Rating,
                Description = review.Description,
                DoctorId = review.DoctorId,
                PatientId = review.PatientId
            });
        }

        public void Update(Review newReview)
        {
            var entity = _context.Reviews.Find(newReview.Id);
            entity.DoctorId = newReview.DoctorId;
            entity.PatientId = newReview.PatientId;
            entity.Rating = (Rating)newReview.Rating;
            entity.Description = newReview.Description;

            _context.Reviews.Update(entity);
            _context.SaveChanges();
        }
    }
}
