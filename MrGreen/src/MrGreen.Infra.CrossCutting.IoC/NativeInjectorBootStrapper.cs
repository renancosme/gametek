using Microsoft.Extensions.DependencyInjection;
using MrGreen.Application.Repository;
using MrGreen.Application.Services;
using MrGreen.Application.Services.Interfaces;
using MrGreen.Infra.Data.Repository;
using System;

namespace MrGreen.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Infra - Data
            services.AddScoped<ICustormerRepository, CustomerRepository>();
        }
    }
}
