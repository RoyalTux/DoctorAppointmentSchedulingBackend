using AutoMapper;
using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    public abstract class BaseController<TViewModel, TDomainModel, TService, T> : ControllerBase
        where TViewModel : class, IEntity<T>
        where TDomainModel : class, IEntity<T>
        where TService : IService<TDomainModel, T>
    {
        private readonly TService _service;
        private readonly IMapper _mapper;

        public BaseController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TViewModel>>> Get()
        {
            List<TDomainModel> domainEntities = await _service.GetAll();

            List<TViewModel> viewModels = _mapper.Map<List<TViewModel>>(domainEntities);

            return viewModels;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TViewModel>> Get(T id)
        {
            TDomainModel domainEntity = await _service.GetById(id);

            TViewModel viewModel = _mapper.Map<TViewModel>(domainEntity);

            if (viewModel == null)
            {
                return NotFound();
            }

            return viewModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(T id, TViewModel viewModel)
        {
            if(!id.Equals(viewModel.Id))
            {
                return BadRequest();
            }

            TDomainModel domainEntity = _mapper.Map<TDomainModel>(viewModel);

            await _service.Update(domainEntity);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TViewModel>> Post(TViewModel viewModel)
        {
            TDomainModel domainModel = _mapper.Map<TDomainModel>(viewModel);

            await _service.Add(domainModel);

            return CreatedAtAction("Get", new { id = viewModel.Id }, viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TViewModel>> Delete(T id)
        {
            TDomainModel domainModel = await _service.Delete(id);

            if (domainModel == null)
            {
                return NotFound();
            }

            TViewModel viewModel = _mapper.Map<TViewModel>(domainModel);

            return viewModel;
        }
    }
}
