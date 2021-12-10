using PetVet.Domain.Common;
using PetVet.Domain.Entities.Users;
using PetVet.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetVet.Domain.Entities.Customers
{
    public class Customer : Entity, IAggregateRoot
    {
        private readonly List<Pet> _pets;
        private readonly List<CreditCard> _creditCards;

        public Name Name { get; private set; }

        public DateTime Birthday { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; }

        public IReadOnlyList<Pet> Pets => _pets.AsReadOnly();

        public IReadOnlyList<CreditCard> CreditCards => _creditCards.AsReadOnly();

        // EF
        private Customer() { }

        public Customer(string firstName,
            string lastName,
            DateTime birthday)
        {
            Birthday = birthday;
            Name = new Name(firstName, lastName);

            _creditCards = new List<CreditCard>();
            _pets = new List<Pet>();
        }

        public void AddNewPet(Pet pet)
        {
            _pets.Add(pet);
        }

        public void AddNewCreditCard(CreditCard card)
        {
            _creditCards.Add(card);
        }

        public void RemovePet(Pet pet)
        {
            _pets.Remove(pet);
        }

        public void RemoveCreditCard(CreditCard card)
        {
            _creditCards.Remove(card);
        }

        public Pet FindPetByFirstName(string firstName)
        {
            return Pets
                .FirstOrDefault(x => x.Name.FirstName == firstName);
        }

        public CreditCard FindCreditCardByLastNumbers(string lastNumbers)
        {
            return CreditCards
                .FirstOrDefault(x => x.Number == lastNumbers);
        }
    }
}