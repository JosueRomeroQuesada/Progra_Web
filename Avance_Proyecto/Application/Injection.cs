using Application.Clients;
using Domain.Clients;
using Application.Instructors;
using Domain.Instructors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ClientProfile));

            services.AddScoped<IClientService, ClientService>();

            return services;
        }

        public static IServiceCollection AddApplicationServicesInstructor
           (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(InstructorProfile));

            services.AddScoped<IInstructorService, InstructorService>();

            return services;
        }
    }

}
