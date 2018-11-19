using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Redbet.Application.Interfaces;
using Redbet.Application.Services;
using Redbet.Domain.Core.Bus;
using Redbet.Domain.Core.Events;
using Redbet.Domain.Core.Notifications;
using Redbet.Domain.Interfaces;
using Redbet.Domain.Models.Customers.CommandHandlers;
using Redbet.Domain.Models.Customers.Commands;
using Redbet.Domain.Models.Customers.EventHandlers;
using Redbet.Domain.Models.Customers.Events;
using Redbet.Domain.Models.Customers.Repository;
using Redbet.Infra.CrossCutting.Bus;
using Redbet.Infra.Data.Context;
using Redbet.Infra.Data.Repository;
using Redbet.Infra.Data.UnitOfWork;

namespace Redbet.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Commands para CommandHandlers
            services.AddScoped<IHandler<AddCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<IHandler<DeleteCustomerCommand>, CustomerCommandHandler>();

            // Domain - Events para EventHandlers
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<AddedCustomerEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<UpdatedCustomerEvent>, CustomerEventHandler>();
            services.AddScoped<IHandler<DeletedCustomerEvent>, CustomerEventHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CustomersContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}
