using DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        int Add(Doctor newDoctor);

        Doctor Get(int id);

        void Update(Doctor newDoctor);

        void Delete(int newDoctor);

        double GetRating(int DoctorId);
    }
}
