using System;
using System.Collections.Generic;
using System.Linq;
using DoctorAppointmentScheduling.DataAccess.Models;
using DoctorAppointmentScheduling.Domain.Interfaces;
using domain = DoctorAppointmentScheduling.Domain.Models;

namespace DoctorAppointmentScheduling.DataAccess.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataBaseContext _context;

        public BookingRepository(DataBaseContext context)
        {
            _context = context;
        }

        public int Add(domain.Booking newBooking)
        {
            var entity = new Booking
            {
                Date = newBooking.Date,
                DoctorId = newBooking.DoctorId,
                UserId = newBooking.UserId,
                Description = newBooking.Description
            };

            _context.Bookings.Add(entity);

            _context.SaveChanges();

            return entity.BookingId;
        }

        public void Delete(int Id)
        {
            var booking = _context.Bookings.Find(Id);

            if (booking == null)
            {
                throw new ArgumentNullException();
            }

            _context.Bookings.Remove(booking);

            _context.SaveChanges();
        }

        public IEnumerable<domain.Booking> GetByDoctor(int DoctorId)
        {
            var entities = _context.Bookings
                .Where(b => b.DoctorId == DoctorId);

            return entities.Select(e => new domain.Booking
            {
                BookingId = e.BookingId,
                DoctorId = e.DoctorId,
                Description = e.Description,
                Date = e.Date,
                UserId = e.UserId
            });
        }

        public IEnumerable<domain.Booking> GetByUser(int UserId)
        {
            var entities = _context.Bookings
                .Where(b => b.UserId == UserId);

            return entities.Select(e => new domain.Booking
            {
                BookingId = e.BookingId,
                DoctorId = e.DoctorId,
                Description = e.Description,
                Date = e.Date,
                UserId = e.UserId
            });
        }

        public domain.Booking GetById(int BookingId)
        {
            var entity = _context.Bookings.Find(BookingId);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            return new domain.Booking
            {
                BookingId = entity.BookingId,
                Date = entity.Date,
                UserId = entity.UserId,
                DoctorId = entity.DoctorId,
                Description = entity.Description
            };
        }

        public void Update(domain.Booking newBooking)
        {
            var entity = _context.Bookings.Find(newBooking.BookingId);

            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.Description = newBooking.Description;
            entity.Date = DateTime.Now;
            entity.DoctorId = newBooking.DoctorId;
            entity.UserId = newBooking.UserId;

            _context.Bookings.Update(entity);

            _context.SaveChanges();
        }
    }
}
