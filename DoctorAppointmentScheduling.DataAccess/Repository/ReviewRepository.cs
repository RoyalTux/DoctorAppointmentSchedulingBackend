using AutoMapper;
using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Dtos;
using DoctorAppointmentScheduling.Domain.Entities;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class ReviewRepository : RepositoryBase<Review, ReviewDto, DataBaseContext>
    {
        public ReviewRepository(DataBaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
