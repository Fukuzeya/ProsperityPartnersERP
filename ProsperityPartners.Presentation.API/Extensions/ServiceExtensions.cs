using MediatR;
using System.Reflection;

namespace ProsperityPartners.Presentation.API.Extensions
{
    public static class ServiceExtensions
    {
        //Configure Cors
        public static IServiceCollection ConfigurePresentationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
            return services;
        }

    }
}
