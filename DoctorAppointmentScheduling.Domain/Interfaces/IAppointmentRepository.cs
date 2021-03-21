using DoctorAppointmentScheduling.Domain.Models;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IAppointmentRepository : IBaseRepository<Appointment>
    {
        IEnumerable<Appointment> GetByDoctor(int Id);

        IEnumerable<Appointment> GetByPatient(int Id);
    }
}
