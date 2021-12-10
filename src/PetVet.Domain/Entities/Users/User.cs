using PetVet.Domain.Common;
using PetVet.Domain.Entities.Assistants;
using PetVet.Domain.Entities.Customers;
using PetVet.Domain.Entities.Vets;
using System;

namespace PetVet.Domain.Entities.Users
{
    public class User : Entity, IAggregateRoot
    {
        public string Email { get; private set; }

        public string Login { get; private set; }

        public string Role { get; private set; }

        public Guid IdentityServerUserId { get; private set; }

        public Customer Customer { get; private set; }

        public Vet Vet { get; private set; }

        public Assistant Assistant { get; private set; }

        public User(string email,
            string login,
            string role,
            Guid identityServerUserId)
        {
            Email = email;
            Login = login;
            Role = role;
            IdentityServerUserId = identityServerUserId;
        }

        public void AssignCustomer(Customer customer)
        {
            Customer = customer;
        }
    }
}