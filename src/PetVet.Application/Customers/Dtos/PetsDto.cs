using System.Collections.Generic;

namespace PetVet.Application.Customers.Dtos
{
    public class PetsDto
    {
        public IEnumerable<PetDto> Pets { get; private set; }

        public PetsDto(IEnumerable<PetDto> pets)
        {
            Pets = pets;
        }
    }
}