using System.Linq;
using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using DoctorAppointmentScheduling.DataAccess.Dtos;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class DoctorRepository : RepositoryBase<Doctor, DoctorDto, ClinicDbContext>
    {
        private readonly ClinicDbContext _context;
        private readonly IMapper _mapper;

        public DoctorRepository(ClinicDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Rating> GetRating(int id)
        {
            IEnumerable<ReviewDto> reviewsDto = await _context.Reviews.Where(r => r.DoctorId == id).ToListAsync();

            IEnumerable<Review> reviews = _mapper.Map<IEnumerable<Review>>(reviewsDto);

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
