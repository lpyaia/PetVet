using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace PetVet.Infrastructure.Identity.Context
{
    public class DesignTimeDbContextFactoryBase : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                             .SetBasePath(Directory.GetCurrentDirectory() + @"\Identity")
                                             .AddJsonFile("appsettings.json")
                                             .Build();

            var connectionString =
                configuration.GetConnectionString("BaseAppDbContext");

            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.Configure<OperationalStoreOptions>(x => { });

            var context = services.BuildServiceProvider().GetService<ApplicationDbContext>();

            return context;
        }
    }
}