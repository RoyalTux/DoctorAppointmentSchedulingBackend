using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Services;
using DoctorAppointmentScheduling.WebAPi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : BaseController<ReviewViewModel, Review, ReviewService>
    {
        public ReviewsController(ReviewService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}