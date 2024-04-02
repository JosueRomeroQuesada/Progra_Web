﻿using Application.Clients;
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




            return services;
        }
    }
}
