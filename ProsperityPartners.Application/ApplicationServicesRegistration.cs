using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProsperityPartners.Application.LoggerService;
using ProsperityPartners.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton<ILoggerManager, LoggerManager>();

            return services;
        }
    }
}
