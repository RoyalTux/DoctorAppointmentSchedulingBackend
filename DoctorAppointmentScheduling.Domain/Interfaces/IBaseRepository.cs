using System.Collections.Generic;

namespace DoctorAppointmentScheduling.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        int Add(T newEntity);

        T Get(int Id);

        IEnumerable<T> GetAll(string name);

        int Update(T newEntity);

        void Delete(int Id);
    }
}
