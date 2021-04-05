using AutoMapper;
using DoctorAppointmentScheduling.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public abstract class RepositoryBase<TDomainEntity, TDtoEntity, TContext> : IRepositoryBase<TDomainEntity>
        where TDomainEntity : class, IEntity
        where TDtoEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly IMapper _mapper;

        public RepositoryBase(TContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TDomainEntity>> GetAll()
        {
            List<TDtoEntity> dtoEntities = await _context.Set<TDtoEntity>().ToListAsync();

            List<TDomainEntity> entites = _mapper.Map<List<TDomainEntity>>(dtoEntities);

            return entites;
        }

        public async Task<TDomainEntity> GetById(int id)
        {
            TDtoEntity dtoEntity = await _context.Set<TDtoEntity>().FindAsync(id);

            TDomainEntity entity = _mapper.Map<TDomainEntity>(dtoEntity);

            return entity;
        }

        public async Task<TDomainEntity> Add(TDomainEntity entity)
        {
            TDtoEntity dtoEntity = _mapper.Map<TDtoEntity>(entity);

            _context.Set<TDtoEntity>().Add(dtoEntity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TDomainEntity> Update(TDomainEntity entity)
        {
            TDtoEntity dtoEntity = _mapper.Map<TDtoEntity>(entity);

            _context.Entry(dtoEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TDomainEntity> Delete(int id)
        {
            TDtoEntity dtoEntity = await _context.Set<TDtoEntity>().FindAsync(id);

            TDomainEntity entity = _mapper.Map<TDomainEntity>(dtoEntity);

            if (dtoEntity == null)
            {
                return entity;
            }

            _context.Set<TDtoEntity>().Remove(dtoEntity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
