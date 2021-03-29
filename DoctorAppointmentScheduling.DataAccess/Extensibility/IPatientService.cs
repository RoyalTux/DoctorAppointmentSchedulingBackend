using DoctorAppointmentScheduling.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.DataAccess.Extensibility
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllPatinents();

        Task<Patient> GetPatinentById(int id);

        Task<Patient> AddPatinent(Patient entity);

        Task<Patient> UpdatePatinent(Patient entity);

        Task<Patient> DeletePatinent(int id);
    }
}
