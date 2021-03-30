using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : BaseController<Review, RepositoryBase<Review, DataBaseContext>>
    {
        public ReviewsController(RepositoryBase<Review, DataBaseContext> repository) : base(repository)
        {
        }
    }
}