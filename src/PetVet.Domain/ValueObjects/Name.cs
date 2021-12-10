using PetVet.Domain.Common;
using System.Collections.Generic;

namespace PetVet.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;

            if (LastName.IsNotNullAndNotEmpty())
            {
                yield return LastName!;
            }
        }
    }
}