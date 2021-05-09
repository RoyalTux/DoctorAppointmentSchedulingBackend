using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.Service.Services
{
    public class PatientService : IService<Patient, Guid>
    {
        private readonly PatientRepository _repository;

        public PatientService(PatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Patient> GetById(Guid id)
        {
            var entity = await _repository.GetById(id);

            return entity;
        }

        public async Task<Patient> Update(Patient entity)
        {
            await _repository.Update(entity);

            return entity;
        }

        public async Task<Patient> Add(Patient entity)
        {
            await _repository.Add(entity);

            return entity;
        }

        public async Task<Patient> Delete(Guid id)
        {
            var entity = await _repository.Delete(id);

            return entity;
        }
    }
}
