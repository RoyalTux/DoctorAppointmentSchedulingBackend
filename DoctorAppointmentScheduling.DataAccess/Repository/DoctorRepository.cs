using System.Linq;
using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.DataAccess.Context;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class DoctorRepository : RepositoryBase<Doctor, DataBaseContext>
    {
        private readonly DataBaseContext _context;

        public DoctorRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Rating> GetRating(int id)
        {
            IEnumerable<Review> reviews = await _context.Reviews.Where(r => r.DoctorId == id).ToListAsync();
            
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
