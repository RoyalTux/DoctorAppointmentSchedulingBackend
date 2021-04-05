using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Services;
using DoctorAppointmentScheduling.WebAPi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : BaseController<AppointmentViewModel, Appointment, AppointmentService>
    {
        public AppointmentsController(AppointmentService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}
