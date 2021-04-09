using AutoMapper;
using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Dtos;
using DoctorAppointmentScheduling.Domain.Entities;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment, AppointmentDto, ClinicDbContext>
    {
        public AppointmentRepository(ClinicDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
