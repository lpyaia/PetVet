using Ardalis.Specification.EntityFrameworkCore;
using PetVet.Application.Common.Interfaces;
using PetVet.Domain.Common;
using PetVet.Persistence.Context;

namespace PetVet.Persistence.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T>
        where T : Entity, IAggregateRoot
    {
        public Repository(BaseAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}