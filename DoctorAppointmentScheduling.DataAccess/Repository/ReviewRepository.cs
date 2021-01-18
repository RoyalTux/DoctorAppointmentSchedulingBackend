using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using domain = DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataBaseContext _context;

        public ReviewRepository(DataBaseContext context)
        {
            _context = context;
        }

        public int Add(domain.Review newReview)
        {
            var entity = new Review
            {
                DoctorId = newReview.DoctorId,
                UserId = newReview.UserId,
                Rating = newReview.Rating,
                Content = newReview.Content
            };

            _context.Reviews.Add(entity);

            _context.SaveChanges();

            return entity.ReviewId;
        }

        public void Delete(int Id)
        {
            var entity = _context.Reviews.Find(Id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _context.Reviews.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<domain.Review> GetReviews(int DoctorId)
        {
            var entities = _context.Reviews
                .Where(r => r.DoctorId == DoctorId);

            return entities.Select(m => new domain.Review
            {
                ReviewId = m.ReviewId,
                Rating = m.Rating,
                Content = m.Content,
                DoctorId = m.DoctorId,
                UserId = m.UserId
            });
        }

        public void Update(domain.Review newReview)
        {
            var entity = _context.Reviews.Find(newReview.ReviewId);
            entity.DoctorId = newReview.DoctorId;
            entity.UserId = newReview.UserId;
            entity.Rating = newReview.Rating;
            entity.Content = newReview.Content;

            _context.Reviews.Update(entity);

            _context.SaveChanges();
        }
    }
}
