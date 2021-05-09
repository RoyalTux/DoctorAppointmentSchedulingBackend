using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.Service.Services
{
    public class AppointmentService : IService<Appointment, int>
    {
        private readonly AppointmentRepository _repository;

        public AppointmentService(AppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Appointment>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Appointment> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return entity;
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            await _repository.Update(entity);

            return entity;
        }

        public async Task<Appointment> Add(Appointment entity)
        {
            await _repository.Add(entity);

            return entity;
        }

        public async Task<Appointment> Delete(int id)
        {
            var entity = await _repository.Delete(id);

            return entity;
        }
    }
}
