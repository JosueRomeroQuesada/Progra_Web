using Application.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Clients;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Application.Contexts;
using Persistence.Clients;
using Persistence.Repositories;
using Application.Courses;
using Persistence.Courses;
using Domain.Courses;

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

            return services;
        }
    }
}
