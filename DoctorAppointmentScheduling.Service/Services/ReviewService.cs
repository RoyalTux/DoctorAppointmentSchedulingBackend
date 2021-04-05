using DoctorAppointmentScheduling.DataAccess.Repository;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorAppointmentScheduling.Service.Services
{
    public class ReviewService : IService<Review>
    {
        private readonly ReviewRepository _repository;

        public ReviewService(ReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Review>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Review> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return entity;
        }

        public async Task<Review> Update(Review entity)
        {
            await _repository.Update(entity);

            return entity;
        }

        public async Task<Review> Add(Review entity)
        {
            await _repository.Add(entity);

            return entity;
        }

        public async Task<Review> Delete(int id)
        {
            var entity = await _repository.Delete(id);

            return entity;
        }
    }
}
