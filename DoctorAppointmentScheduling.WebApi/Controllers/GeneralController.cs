using DoctorAppointmentScheduling.Domain.Extensibility;
using DoctorAppointmentScheduling.Domain.Extensibility.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    public class GeneralController<TDomainEntity, TRepository> : ControllerBase
        where TDomainEntity : class, IEntity
        where TRepository : IRepositoryBase<TDomainEntity>
    {
        private readonly TRepository _repository;

        public GeneralController(TRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDomainEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDomainEntity>> Get(int id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TDomainEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            await _repository.Update(entity);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TDomainEntity>> Post(TDomainEntity entity)
        {
            await _repository.Add(entity);

            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TDomainEntity>> Delete(int id)
        {
            var entity = await _repository.Delete(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }
    }
}
