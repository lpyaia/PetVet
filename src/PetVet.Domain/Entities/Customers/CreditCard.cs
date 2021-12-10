using PetVet.Domain.Common;
using System;

namespace PetVet.Domain.Entities.Customers
{
    public class CreditCard : Entity
    {
        public string Number { get; private set; }

        public string Cvv { get; private set; }

        public int ExpirationMonth { get; private set; }

        public int ExpirationYear { get; private set; }

        public Guid OwnerId { get; private set; }

        public Customer Owner { get; private set; }

        // EF
        private CreditCard() { }

        public CreditCard(string number,
            string cvv,
            int expirationMonth,
            int expirationYear,
            Guid ownerId)
        {
            Number = number;
            Cvv = cvv;
            ExpirationMonth = expirationMonth;
            ExpirationYear = expirationYear;
            OwnerId = ownerId;
        }
    }
}