using DoctorAppointmentScheduling.Domain.Extensibility;
using DoctorAppointmentScheduling.Domain.Extensibility.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.Domain.Repository
{
    public class RepositoryBase<TDomainEntity, TContext> : IRepositoryBase<TDomainEntity>
        where TDomainEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task<List<TDomainEntity>> GetAll()
        {
            return await _context.Set<TDomainEntity>().ToListAsync();
        }

        public async Task<TDomainEntity> GetById(int id)
        {
            return await _context.Set<TDomainEntity>().FindAsync(id);
        }

        public async Task<TDomainEntity> Add(TDomainEntity entity)
        {
            _context.Set<TDomainEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TDomainEntity> Update(TDomainEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TDomainEntity> Delete(int id)
        {
            var entity = await _context.Set<TDomainEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }

            _context.Set<TDomainEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
