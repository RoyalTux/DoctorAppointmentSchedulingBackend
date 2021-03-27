using System.Linq;
using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Context;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Repository
{
    public class DoctorRepository : RepositoryBase<Doctor, DataBaseContext>
    {
        private readonly DataBaseContext _context;

        public DoctorRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public Rating GetRating(int id)
        {
            IEnumerable<Review> reviews = _context.Reviews.Where(r => r.DoctorId == id);

            int sum = 0;
            int count = 0;

            foreach (Review review in reviews)
            {
                sum += (int)review.Rating;
                count++;
            }

            if(count == 0)
            {
                count = 1;
            }

            return (Rating)(sum / count);
        }
    }
}
