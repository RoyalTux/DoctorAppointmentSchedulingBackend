using AutoMapper;
using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Dtos;
using DoctorAppointmentScheduling.Domain.Entities;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class AppointmentRepository : RepositoryBase<Appointment, AppointmentDto, DataBaseContext>
    {
        public AppointmentRepository(DataBaseContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
