using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DoctorAppointmentScheduling.DataAccess.Context
{
    public class ClinicDbContextFactory : IDesignTimeDbContextFactory<ClinicDbContext>
    {
        public ClinicDbContext CreateDbContext(string[] args)
        {
            // string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ClinicDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DoctorAppointmentSchedulingDb;Trusted_Connection=True;");

            return new ClinicDbContext(optionsBuilder.Options);
        }
    }
}
