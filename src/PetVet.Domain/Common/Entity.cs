using System;
using System.Collections.Generic;

namespace PetVet.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public ICollection<DomainEvent> DomainEvents { get; protected set; }
            = new HashSet<DomainEvent>();
    }
}