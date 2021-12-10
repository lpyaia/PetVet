using Ardalis.Specification;
using PetVet.Domain.Common;

namespace PetVet.Application.Common.Interfaces
{
    public interface IRepository<T> : IRepositoryBase<T>
        where T : Entity, IAggregateRoot
    {
    }
}