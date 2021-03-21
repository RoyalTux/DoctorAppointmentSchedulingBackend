using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Rating GetRating(int Id);
    }
}
