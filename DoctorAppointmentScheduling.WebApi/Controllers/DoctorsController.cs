using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Service.Services;
using DoctorAppointmentScheduling.WebAPi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorsController : BaseController<DoctorViewModel, Doctor, DoctorService>
    {
        private readonly DoctorService _service;

        public DoctorsController(DoctorService service, IMapper mapper) : base(service, mapper)
        {
            _service = service;
        }

        [HttpGet("Rating/{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
            var entity = await _service.GetRating(id);

            return entity;
        }
    }
}
