using PetVet.Domain.Common;
using PetVet.Domain.Entities.Users;
using System;

namespace PetVet.Domain.Entities.Assistants
{
    public class Assistant : Entity
    {
        public Guid UserId { get; private set; }

        public User User { get; private set; }
    }
}