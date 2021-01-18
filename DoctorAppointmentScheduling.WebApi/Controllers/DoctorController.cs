﻿using DoctorAppointmentScheduling.Domain.Interfaces;
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
            return Ok(result);
        }

        // POST api/<DoctorController>
        [HttpPost]
        public IActionResult Post([FromBody] Doctor doc)
        {
            var newDocID = _doctorRepository.Add(doc);
            var newDoc = _doctorRepository.Get(newDocID);
            return Created($"api/<DoctorContoller>/{newDocID}", newDoc);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Doctor Doc)
        {
            _doctorRepository.Update(Doc);
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