using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController<Appointment, RepositoryBase<Appointment, DataBaseContext>>
    {
        public AppointmentsController(RepositoryBase<Appointment, DataBaseContext> repository) : base(repository)
        {
        }
    }
}
