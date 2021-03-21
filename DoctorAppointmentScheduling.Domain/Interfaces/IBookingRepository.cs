using DoctorAppointmentScheduling.Domain.Models;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        IEnumerable<Booking> GetByDoctor(int Id);

        IEnumerable<Booking> GetByPatient(int Id);
    }
}
