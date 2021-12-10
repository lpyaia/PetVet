using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetVet.Application.Common.Interfaces;
using PetVet.Persistence.Context;
using PetVet.Persistence.Repositories;

namespace PetVet.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<BaseAppDbContext>(options =>
                    options.UseInMemoryDatabase("inmemory-db"));
            }
            else
            {
                services.AddDbContext<BaseAppDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("BaseAppDbContext"),
                        b => b.MigrationsAssembly(typeof(BaseAppDbContext).Assembly.FullName)));
            }

            services.AddScoped<IBaseAppDbContext>(provider => provider.GetService<BaseAppDbContext>());
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}