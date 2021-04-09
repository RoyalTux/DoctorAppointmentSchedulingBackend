using AutoMapper;
using DoctorAppointmentScheduling.DataAccess.Context;
using DoctorAppointmentScheduling.DataAccess.Dtos;
using DoctorAppointmentScheduling.Domain.Entities;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class PatientRepository : RepositoryBase<Patient, PatientDto, ClinicDbContext>
    {
        public PatientRepository(ClinicDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
