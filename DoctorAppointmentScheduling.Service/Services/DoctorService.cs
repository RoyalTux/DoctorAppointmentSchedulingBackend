using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Enums;
using DoctorAppointmentScheduling.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.Service.Services
{
    public class DoctorService : IService<Doctor, Guid>
    {
        private readonly DoctorRepository _repository;

        public DoctorService(DoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Doctor> GetById(Guid id)
        {
            var entity = await _repository.GetById(id);

            return entity;
        }

        public async Task<Doctor> Update(Doctor entity)
        {
            await _repository.Update(entity);

            return entity;
        }

        public async Task<Doctor> Add(Doctor entity)
        {
            await _repository.Add(entity);

            return entity;
        }

        public async Task<Doctor> Delete(Guid id)
        {
            var entity = await _repository.Delete(id);

            return entity;
        }

        public async Task<Rating> GetRating(Guid id)
        {
            var entity = await _repository.GetRating(id);

            return entity;
        }
    }
}
