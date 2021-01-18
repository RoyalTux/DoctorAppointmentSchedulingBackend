using DoctorAppointmentScheduling.Domain.Models;
using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IBookingRepository
    {
        int Add(Booking newBooking);

        Booking GetById(int id);

        IEnumerable<Booking> GetByDoctor(int DoctorId);

        IEnumerable<Booking> GetByUser(int UserId);

        void Delete(int Id);

        void Update(Booking newBooking);
    }
}
