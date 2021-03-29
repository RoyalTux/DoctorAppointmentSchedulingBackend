using DoctorAppointmentScheduling.Domain.Context;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : BaseController<Patient, RepositoryBase<Patient, DataBaseContext>>
    {
        public PatientsController(RepositoryBase<Patient, DataBaseContext> repository) : base(repository)
        {
        }
    }
}