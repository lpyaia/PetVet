using System;
using System.Collections.Generic;

namespace PetVet.Domain.Common
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }

    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            DateOcurred = DateTimeOffset.UtcNow;
        }

        public bool IsPublished { get; set; }

        public DateTimeOffset DateOcurred { get; protected set; }
    }
}