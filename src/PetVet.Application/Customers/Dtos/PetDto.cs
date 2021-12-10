using System;

namespace PetVet.Application.Customers.Dtos
{
    public class PetDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TutorId { get; set; }
    }
}