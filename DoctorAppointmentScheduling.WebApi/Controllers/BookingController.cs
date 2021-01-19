using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
            var booking = _bookingRepository.GetById(id);

            if (booking != null)
            {
                return Ok(booking);
            }
            else
            {
                return NotFound();
            }
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
            var booking = _bookingRepository.GetByDoctor(id);
            int bookingsNumber = 0;

            using (IEnumerator<Booking> enumerator = booking.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    bookingsNumber++;
            }

            if (booking != null && bookingsNumber != 0)
            {
                return Ok(booking);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("user/{id}")]
        public IActionResult GetByUser(int id)
        {
            var booking = _bookingRepository.GetByUser(id);
            int bookingsNumber = 0;

            using (IEnumerator<Booking> enumerator = booking.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    bookingsNumber++;
            }

            if (booking != null && bookingsNumber != 0)
            {
                return Ok(booking);
            }
            else
            {
                return NotFound();
            }
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
