using System.Linq;
using DoctorAppointmentScheduling.DataAccess.Enums;
using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataBaseContext _context;

        public DoctorRepository(DataBaseContext context)
        {
            _context = context;
        }

        public Doctor Get(int id)
        {
            var doctor = _context.Doctors.Find(id);

            return new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
                Country = doctor.Country,
                City = doctor.City,
                Bio = doctor.Bio,
                ExperienceYears = doctor.ExperienceYears,
                Phone = doctor.Phone,
                Rating = (Domain.Enums.Rating?)doctor.Rating
            };
        }

        public int Add(Doctor newDoctor)
        {
            var entity = new DoctorDataEntity
            {
                FirstName = newDoctor.FirstName,
                LastName = newDoctor.LastName,
                Email = newDoctor.Email,
                Country = newDoctor.Country,
                City = newDoctor.City,         
                Bio = newDoctor.Bio,
                ExperienceYears = newDoctor.ExperienceYears,
                Phone = newDoctor.Phone,
                Rating = Rating.NO_RATING
            };

            _context.Doctors.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public int Update(Doctor newDoctor)
        {
            var entity = _context.Doctors.Find(newDoctor.Id);

            entity.Bio = newDoctor.Bio;
            entity.Country = newDoctor.Country;
            entity.City = newDoctor.City;
            entity.Email = newDoctor.Email;
            entity.ExperienceYears = newDoctor.ExperienceYears;
            entity.FirstName = newDoctor.FirstName;
            entity.LastName = newDoctor.LastName;
            entity.Phone = newDoctor.Phone;

            _context.Doctors.Update(entity);
            _context.SaveChanges();

            return newDoctor.Id;
        }

        public void Delete(int id)
        {
            var entity = _context.Doctors.Find(id);

            _context.Doctors.Remove(entity);
            _context.SaveChanges();
        }

        public Domain.Enums.Rating GetRating(int id)
        {
            var ratings = _context.Reviews
                .Where(r => r.DoctorId == id);

            int sum = 0;
            int count = 0;

            foreach (ReviewDataEntity review in ratings)
            {
                sum += (int)review.Rating;
                count++;
            }

            return (Domain.Enums.Rating)(sum / count);
        }
    }
}
