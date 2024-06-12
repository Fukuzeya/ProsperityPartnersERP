using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProsperityPartners.Application.Contracts.Persistance;
using ProsperityPartners.Domain.Entities;
using ProsperityPartners.Persistance.Context;
using ProsperityPartners.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsperityPartners.Persistance
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigurePersistanceServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();


            return services;
        }

        public static void ConfigureMySqlContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(opts =>opts
            .UseMySql(configuration.GetConnectionString("DefaultConnection"), 
            MySqlServerVersion.LatestSupportedServerVersion));
        }

    }
}
