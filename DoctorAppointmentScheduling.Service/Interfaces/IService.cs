using DoctorAppointmentScheduling.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.Service.Interfaces
{
    public interface IService<TDomainEntity>
        where TDomainEntity : class, IEntity
    {
        Task<List<TDomainEntity>> GetAll();

        Task<TDomainEntity> GetById(int id);

        Task<TDomainEntity> Add(TDomainEntity entity);

        Task<TDomainEntity> Update(TDomainEntity entity);

        Task<TDomainEntity> Delete(int id);
    }
}
