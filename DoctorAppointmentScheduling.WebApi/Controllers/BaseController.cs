using AutoMapper;
using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.WebAPi.Controllers
{
    public abstract class BaseController<TViewModel, TDomainModel, TService> : ControllerBase
        where TViewModel : class, IEntity
        where TDomainModel : class, IEntity
        where TService : IService<TDomainModel>
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
        public async Task<ActionResult<TViewModel>> Get(int id)
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
        public async Task<IActionResult> Put(int id, TViewModel viewModel)
        {
            if (id != viewModel.Id)
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
        public async Task<ActionResult<TViewModel>> Delete(int id)
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
