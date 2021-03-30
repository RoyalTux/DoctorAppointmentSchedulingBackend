using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
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