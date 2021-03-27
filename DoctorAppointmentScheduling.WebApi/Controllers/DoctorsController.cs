using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : GeneralController<Doctor, DoctorsRepository>
    {
        private readonly DoctorsRepository _doctorsRepository;

        public DoctorsController(DoctorsRepository doctorsRepository) : base(doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        [HttpGet("Rating/{id}")]
        public ActionResult<Rating> GetRating(int id)
        {
            var entity = _doctorsRepository.GetRating(id);

            return entity;
        }
    }
}
