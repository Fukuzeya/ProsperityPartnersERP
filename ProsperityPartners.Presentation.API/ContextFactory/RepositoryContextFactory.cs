using ProsperityPartners.Persistance.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ProsperityPartners.Presentation.API.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseMySql(configuration.GetConnectionString("DefaultConnection"),
            MySqlServerVersion.LatestSupportedServerVersion,
            b => b.MigrationsAssembly("ProsperityPartners.Presentation.API"));
            return new RepositoryContext(builder.Options);
        }
    }
}
