using Microsoft.EntityFrameworkCore;
using PetVet.Persistence.Context;

using System;

namespace PetVet.Application.UnitTests.Helpers
{
    public static class BaseAppDbContextInMemoryFactory
    {
        public static BaseAppDbContext CreateInMemoryDb()
        {
            DbContextOptions<BaseAppDbContext> dbOptions = new DbContextOptionsBuilder<BaseAppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var baseAppDb = new BaseAppDbContext(dbOptions);

            return baseAppDb;
        }
    }
}