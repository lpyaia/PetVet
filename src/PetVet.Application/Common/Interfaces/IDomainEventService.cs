using PetVet.Domain.Common;
using System.Threading.Tasks;

namespace PetVet.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}