using DoctorAppointmentScheduling.Domain.Context;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Repository;
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
