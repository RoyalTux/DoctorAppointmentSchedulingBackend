using DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IUserRepository
    {
        int Add(User newUser);

        User Get(int Id);

        int Update(User newUser);

        void Delete(int Id);
    }
}
