using MediatR;
using PetVet.Application.Common.Models;
using PetVet.Application.Customers.Dtos;
using System;

namespace PetVet.Application.Customers.Features.ViewPets
{
    public class ViewCustomerPetsQuery : IRequest<Result<PetsDto>>
    {
        public Guid CustomerId { get; set; }
    }
}