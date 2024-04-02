using Application.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Clients;
using Domain.Machines;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Application.Contexts;
using Persistence.Clients;
using Persistence.Machines;
using Application.Instructors;

using Persistence.Repositories;
using Application.Courses;
using Persistence.Courses;
using Domain.Courses;
using Application.Machines;
using Domain.Instructors;

using Persistence.Instructors;

namespace Persistence
{
    public static class Injection
    {
        public static IServiceCollection AddPersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<IApplicationDbContext>
                (options => options.GetService<ApplicationDbContext>());

            services.AddRepository<Client, IClientRepository, ClientRepository>();
            services.AddRepository<Course, ICourseRepository, CourseRepository>();
            services.AddRepository<Machine, IMachineRepository, MachineRepository>();
            services.AddRepository<Instructor, IInstructorRepository, InstructorRepository>();

            return services;
        }
    }
}
