namespace ProsperityPartners.Presentation.API.Extensions
{
    public static class ServiceExtensions
    {
        //Configure Cors
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

    }
}
