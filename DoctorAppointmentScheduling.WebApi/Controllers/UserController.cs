using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userRepository.Get(id);

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var newUserId = _userRepository.Add(user);
            var newUser = _userRepository.Get(newUserId);

            return Created($"api/<UserController>/{newUserId}", newUser);
        }

        // PUT api/<UserController>
        [HttpPut()]
        public IActionResult Put([FromBody] User user)
        {
            _userRepository.Update(user);

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);

            return Ok();
        }
    }
}
