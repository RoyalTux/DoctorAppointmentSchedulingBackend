using System;
using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using domain = DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }

        public int Add(domain.Patient newUser)
        {
            var entity = new User
            {
                UserName = newUser.UserName,
                PassWord = newUser.PassWord,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Country = newUser.Country,
                City = newUser.City.ToLower(),
                Phone = newUser.Phone
            };

            _context.Users.Add(entity);

            _context.SaveChanges();

            return entity.UserId;
        }

        public void Delete(int Id)
        {
            var entity = _context.Users.Find(Id);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _context.Users.Remove(entity);

            _context.SaveChanges();
        }

        public domain.Patient Get(int Id)
        {
            var entity = _context.Users.Find(Id);

            return new domain.Patient
            {
                PatientId = entity.UserId,
                UserName = entity.UserName,
                PassWord = entity.PassWord,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Country = entity.Country,
                City = entity.City,
                Phone = entity.Phone
            };
        }

        public int Update(domain.Patient newUser)
        {
            var entity = _context.Users.Find(newUser.PatientId);

            entity.FirstName = newUser.FirstName;
            entity.LastName = newUser.LastName;
            entity.UserName = newUser.UserName;
            entity.PassWord = newUser.PassWord;
            entity.Country = newUser.Country;
            entity.City = newUser.City;
            entity.Phone = newUser.Phone;
            entity.Email = newUser.Email;

            _context.Users.Update(entity);

            _context.SaveChanges();

            return entity.UserId;
        }
    }
}
