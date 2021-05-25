using DoctorAppointmentScheduling.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.Service.Interfaces
{
    public interface IService<TDomainEntity, T>
        where TDomainEntity : class, IEntity<T>
    {
        Task<List<TDomainEntity>> GetAll();

        Task<TDomainEntity> GetById(T id);

        Task<TDomainEntity> Add(TDomainEntity entity);

        Task<TDomainEntity> Update(TDomainEntity entity);

        Task<TDomainEntity> Delete(T id);
    }
}
