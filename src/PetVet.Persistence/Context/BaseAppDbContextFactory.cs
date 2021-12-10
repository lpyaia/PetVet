using Microsoft.EntityFrameworkCore;

namespace PetVet.Persistence.Context
{
    public class BaseAppDbContextFactory : DesignTimeDbContextFactoryBase<BaseAppDbContext>
    {
        protected override BaseAppDbContext CreateNewInstance(DbContextOptions<BaseAppDbContext> options)
        {
            return new BaseAppDbContext(options);
        }
    }
}