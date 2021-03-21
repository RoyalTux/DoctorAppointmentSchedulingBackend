using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class PatientRepository : IBaseRepository<Patient>
    {
        private readonly DataBaseContext _context;

        public PatientRepository(DataBaseContext context)
        {
            _context = context;
        }

        public int Add(Patient newPatient)
        {
            var entity = new PatientDataEntity
            {
                FirstName = newPatient.FirstName,
                LastName = newPatient.LastName,
                Email = newPatient.Email,
                Country = newPatient.Country,
                City = newPatient.City,
                Phone = newPatient.Phone
            };

            _context.Patients.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Delete(int id)
        {
            var patient = _context.Patients.Find(id);

            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }

        public Patient Get(int Id)
        {
            var patient = _context.Patients.Find(Id);

            return new Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                Country = patient.Country,
                City = patient.City,
                Phone = patient.Phone
            };
        }

        public int Update(Patient newUser)
        {
            var entity = _context.Patients.Find(newUser.Id);

            entity.FirstName = newUser.FirstName;
            entity.LastName = newUser.LastName;
            entity.Country = newUser.Country;
            entity.City = newUser.City;
            entity.Phone = newUser.Phone;
            entity.Email = newUser.Email;

            _context.Patients.Update(entity);
            _context.SaveChanges();

            return entity.Id;
        }
    }
}
