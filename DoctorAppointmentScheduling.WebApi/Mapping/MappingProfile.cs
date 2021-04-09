using AutoMapper;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Entities.Auth;
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

            CreateMap<SignUpViewModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
