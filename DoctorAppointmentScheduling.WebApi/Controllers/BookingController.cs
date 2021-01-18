using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            return Ok(_bookingRepository.GetById(id));
        }

        [HttpPost("create")]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {

            int BookingId = _bookingRepository.Add(booking);
            var result = _bookingRepository.GetById(BookingId);

            return CreatedAtAction(nameof(getById), new { id = BookingId }, result);
        }

        [HttpGet("doctor/{id}")]
        public IActionResult GetByDoctor(int id)
        {
            return Ok(_bookingRepository.GetByDoctor(id));
        }

        [HttpGet("user/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(_bookingRepository.GetByUser(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookingRepository.Delete(id);

            return Ok();
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Booking booking)
        {
            _bookingRepository.Update(booking);

            return Ok();
        }
    }
}
