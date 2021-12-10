using PetVet.Domain.Common;
using PetVet.Domain.ValueObjects;
using System;

namespace PetVet.Domain.Entities.Customers
{
    public class Pet : Entity
    {
        public Name Name { get; private set; }

        public Guid TutorId { get; private set; }

        public Customer Tutor { get; private set; }

        public string Sex { get; private set; }

        // EF
        private Pet() { }

        public Pet(string firstName, string lastName)
        {
            Name = new Name(firstName, lastName);
        }
    }
}