using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _doctorRepository.Get(id);

            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
            
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult Post([FromBody] Doctor doctor)
        {
            var newDoctorId = _doctorRepository.Add(doctor);
            var newDoctor = _doctorRepository.Get(newDoctorId);

            return Created($"api/<DoctorContoller>/{newDoctorId}", newDoctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Doctor Doctor)
        {
            _doctorRepository.Update(Doctor);

            return Ok();
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _doctorRepository.Delete(id);

            return Ok();
        }
    }
}
