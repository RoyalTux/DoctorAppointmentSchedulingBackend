using DoctorAppointmentScheduling.Domain.Context;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : GeneralController<Doctor, RepositoryBase<Doctor, DataBaseContext>>
    {
        public PatientController(RepositoryBase<Doctor, DataBaseContext> repository) : base(repository)
        {
        }
    }
}


//using Microsoft.AspNetCore.Mvc;

//namespace DoctorAppointmentScheduling.WebAPi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PatientController : ControllerBase
//    {
//        private readonly IBaseRepository<Patient> _patientRepository;

//        public PatientController(IBaseRepository<Patient> patientRepository)
//        {
//            _patientRepository = patientRepository;
//        }

//        // GET api/<UserController>/5
//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            var patient = _patientRepository.Get(id);

//            if(patient != null)
//            {
//                return Ok(patient);
//            }
//            else
//            {
//                return NotFound();
//            }
//        }

//        // POST api/<UserController>
//        [HttpPost]
//        public IActionResult Post([FromBody] Patient patient)
//        {
//            var newPatientId = _patientRepository.Add(patient);
//            var newPatient = _patientRepository.Get(newPatientId);

//            return Created($"api/<PatientController>/{newPatientId}", newPatient);
//        }

//        // PUT api/<UserController>
//        [HttpPut()]
//        public IActionResult Put([FromBody] Patient patient)
//        {
//            _patientRepository.Update(patient);

//            return Ok();
//        }

//        // DELETE api/<UserController>/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            _patientRepository.Delete(id);

//            return Ok();
//        }
//    }
//}
