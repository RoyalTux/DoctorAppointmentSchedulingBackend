using DoctorAppointmentScheduling.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentScheduling.Domain.Context
{
    public interface IDataBaseContext
    {
        DbSet<Appointment> Bookings { get; set; }

        DbSet<Doctor> Doctors { get; set; }

        DbSet<Patient> Patients { get; set; }

        DbSet<Review> Reviews { get; set; }
    }
}
