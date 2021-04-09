using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Services;
using DoctorAppointmentScheduling.WebAPi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : BaseController<PatientViewModel, Patient, PatientService>
    {
        public PatientsController(PatientService service, IMapper mapper) : base(service, mapper)
        {
        }
    }
}