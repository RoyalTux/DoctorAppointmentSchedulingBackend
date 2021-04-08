using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.WebAPi.ViewModels;

namespace DoctorAppointmentScheduling.WebAPi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppointmentViewModel, Appointment>().ReverseMap();
            CreateMap<DoctorViewModel, Doctor>().ReverseMap();
            CreateMap<PatientViewModel, Patient>().ReverseMap();
            CreateMap<ReviewViewModel, Review>().ReverseMap();
        }
    }
}
