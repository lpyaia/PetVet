using PetVet.Domain.Common;
using PetVet.Domain.Entities.Users;
using System;

namespace PetVet.Domain.Entities.Vets
{
    public class Vet : Entity
    {
        public Guid UserId { get; private set; }

        public User User { get; private set; }
    }
}