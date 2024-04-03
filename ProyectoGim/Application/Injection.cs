using Application.Clients;
using Application.Ejercicios;
using Domain.Ejercicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Clients;
using FluentValidation;
using Application.Machines;
using Application.Instructors;
using Application.Rutinas;
using Domain.Rutinas;
using Application.Weekdays;
using Domain.Weekdays;

namespace Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ClientProfile));
            services.AddScoped<IValidator<CreateClient>, CreateClientValidator>();
            services.AddScoped<IValidator<UpdateClient>, UpdateClientValidator>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IMachineService, MachineService>();
            services.AddScoped<IInstructorService, InstructorService>();
            services.AddScoped<IEjercicioService, EjercicioService>();
            services.AddScoped<IWeekdayService, WeekdayService>();


            services.AddAutoMapper(typeof(RutinaProfile));
            services.AddScoped<IValidator<CreateRutina>, CreateRutinaValidator>();
            services.AddScoped<IValidator<UpdateRutina>, UpdateRutinaValidator>();
            services.AddScoped<IRutinaService, RutinaService>();

            services.AddAutoMapper(typeof(EjercicioProfile));
            services.AddScoped<IValidator<CreateEjercicio>, CreateEjercicioValidator>();
            services.AddScoped<IValidator<UpdateEjercicio>, UpdateEjercicioValidator>();

			services.AddAutoMapper(typeof(WeekdayProfile));
			services.AddScoped<IValidator<CreateWeekday>, CreateWeekdayValidator>();
			services.AddScoped<IValidator<UpdateWeekday>, UpdateWeekdayValidator>();


			return services;
        }
    }
}
