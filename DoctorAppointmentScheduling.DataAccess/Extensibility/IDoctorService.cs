using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.DataAccess.Extensibility
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctors();

        Task<Doctor> GetDoctorById(int id);

        Task<Doctor> AddDoctor(Doctor entity);

        Task<Doctor> UpdateDoctor(Doctor entity);

        Task<Doctor> DeleteDoctor(int id);

        Task<Rating> GetDoctorRating(int id);
    }
}
