using DoctorAppointmentScheduling.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.DataAccess.Extensibility
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAppointments();

        Task<Appointment> GetAppointmentById(int id);

        Task<Appointment> AddAppointment(Appointment entity);

        Task<Appointment> UpdateAppointment(Appointment entity);

        Task<Appointment> DeleteAppointment(int id);
    }
}
