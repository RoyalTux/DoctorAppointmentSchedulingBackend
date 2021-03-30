using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : BaseController<Doctor, DoctorRepository>
    {
        private readonly DoctorRepository _doctorsRepository;

        public DoctorsController(DoctorRepository doctorsRepository) : base(doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        [HttpGet("Rating/{id}")]
        public async Task<ActionResult<Rating>> GetRating(int id)
        {
            var entity = await _doctorsRepository.GetRating(id);

            return entity;
        }
    }
}
