using DoctorAppointmentScheduling.Domain.Context;
using DoctorAppointmentScheduling.Domain.Entities;
using DoctorAppointmentScheduling.Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;

namespace DoctorAppointmentScheduling
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // defining the policy
                options.AddPolicy(name: "AllowFrontEnd",
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyMethod()
                                        .AllowAnyHeader()
                                        .AllowCredentials();
                                  });
            });

            var builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory());

            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(connectionString));
              
            services.AddScoped<DoctorRepository>();
            services.AddScoped<RepositoryBase<Patient, DataBaseContext>>();
            services.AddScoped<RepositoryBase<Appointment, DataBaseContext>>();
            services.AddScoped<RepositoryBase<Review, DataBaseContext>>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DoctorAppointmentScheduling", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseContext context)

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataBaseContext context)
        {
            context.Database.EnsureCreated();
            // context.Database.EnsureDeleted();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoctorAppointmentScheduling v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowFrontEnd");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseDefaultFiles();

            app.UseStaticFiles();
        }
    }
}
