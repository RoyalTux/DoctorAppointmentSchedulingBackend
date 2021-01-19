using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            var newReviewID = _reviewRepository.Add(review);
            var newReview = _reviewRepository.GetReviews(newReviewID);

            return Created($"api/<ReviewController>/{newReviewID}", newReview);
        }

        [HttpGet("doctor/{id}")]
        public IActionResult GetDoctorReviews(int id)
        {
            var reviews = _reviewRepository.GetReviews(id);

            if(reviews != null)
            {
                return Ok(reviews);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Review review)
        {
            _reviewRepository.Update(review);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _reviewRepository.Delete(id);

            return Ok();
        }
    }
}
