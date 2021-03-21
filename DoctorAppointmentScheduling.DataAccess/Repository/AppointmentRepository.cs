using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DataBaseContext _context;

        public AppointmentRepository(DataBaseContext context)
        {
            _context = context;
        }

        public int Add(Appointment newBooking)
        {
            var entity = new AppointmentDataEntity
            {
                DoctorId = newBooking.DoctorId,
                PatientId = newBooking.PatientId,
                Description = newBooking.Description,
                DateTime = newBooking.DateTime
            };

            _context.Bookings.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);

            _context.Bookings.Remove(booking);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetByDoctor(int id)
        {
            var entities = _context.Bookings
                .Where(booking => booking.DoctorId == id);

            return entities.Select(booking => new Appointment
            {
                Id = booking.Id,
                DoctorId = booking.DoctorId,
                PatientId = booking.PatientId,
                Description = booking.Description,
                DateTime = booking.DateTime
            });
        }

        public IEnumerable<Appointment> GetByPatient(int id)
        {
            var entities = _context.Bookings
                .Where(booking => booking.Id == id);

            return entities.Select(booking => new Appointment
            {
                Id = booking.Id,
                DoctorId = booking.DoctorId,
                PatientId = booking.PatientId,
                Description = booking.Description,
                DateTime = booking.DateTime
            });
        }

        public Appointment Get(int id)
        {
            var booking = _context.Bookings.Find(id);

            if (booking != null)
            {                      
                return new Appointment
                {
                    Id = booking.Id,
                    DoctorId = booking.DoctorId,
                    PatientId = booking.PatientId,
                    Description = booking.Description,
                    DateTime = booking.DateTime
                };
            }

            return null;
        }

        public int Update(Appointment newBooking)
        {
            var booking = _context.Bookings.Find(newBooking.Id);

            booking.DoctorId = newBooking.DoctorId;
            booking.PatientId = newBooking.PatientId;
            booking.Description = newBooking.Description;
            booking.DateTime = DateTime.Now;

            _context.Bookings.Update(booking);
            _context.SaveChanges();

            return newBooking.Id;
        }
    }
}
