using System;
using System.Linq;
using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using domain = DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataBaseContext _context;

        public DoctorRepository(DataBaseContext context)
        {
            _context = context;
        }

        public domain.Doctor Get(int id)
        {
            var entity = _context.Doctors.Find(id);

            return new domain.Doctor
            {
                UserName = entity.UserName,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Bio = entity.Bio,
                Country = entity.Country,
                City = entity.City,        
                DoctorId = entity.DoctorId,
                Email = entity.Email,
                ExperienceYears = entity.ExperienceYears,
                Payment = entity.Payment,
                Phone = entity.Phone,
                Rating = entity.Rating
            };
        }

        public int Add(domain.Doctor newDoctor)
        {
            var entity = new Doctor
            {
                UserName = newDoctor.UserName,
                PassWord = newDoctor.PassWord,
                FirstName = newDoctor.FirstName,
                LastName = newDoctor.LastName,
                Email = newDoctor.Email,
                Country = newDoctor.Country,
                City = newDoctor.City.ToLower(),         
                Bio = newDoctor.Bio,
                ExperienceYears = newDoctor.ExperienceYears,
                Payment = newDoctor.Payment,
                Phone = newDoctor.Phone,
                Rating = 0,
                DoctorType = newDoctor.DoctorType
            };

            _context.Doctors.Add(entity);

            _context.SaveChanges();

            return entity.DoctorId;
        }

        public void Update(domain.Doctor newDoctor)
        {
            var entity = _context.Doctors.Find(newDoctor.DoctorId);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.Bio = newDoctor.Bio;
            entity.Country = newDoctor.Country;
            entity.City = newDoctor.City;
            entity.Email = newDoctor.Email;
            entity.ExperienceYears = newDoctor.ExperienceYears;
            entity.FirstName = newDoctor.FirstName;
            entity.LastName = newDoctor.LastName;
            entity.PassWord = newDoctor.PassWord;
            entity.UserName = newDoctor.UserName;
            entity.Phone = newDoctor.Phone;

            _context.Doctors.Update(entity);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Doctors.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _context.Doctors.Remove(entity);

            _context.SaveChanges();
        }

        public double GetRating(int DoctorId)
        {
            var ratings = _context.Reviews
                .Where(r => r.DoctorId == DoctorId);
            double sum = 0;
            double count = 0;
            foreach (Review x in ratings)
            {
                sum += x.Rating;
                count++;
            }

            return sum / count;
        }
    }
}
