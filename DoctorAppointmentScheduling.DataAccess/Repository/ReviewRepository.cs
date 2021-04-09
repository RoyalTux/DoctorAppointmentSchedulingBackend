using AutoMapper;
using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Dtos;
using DoctorAppointmentScheduling.Domain.Entities;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class ReviewRepository : RepositoryBase<Review, ReviewDto, ClinicDbContext>
    {
        public ReviewRepository(ClinicDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
