using AutoMapper;
using MediatR;
using PetVet.Application.Common.Interfaces;
using PetVet.Application.Common.Models;
using PetVet.Application.Customers.Dtos;
using PetVet.Application.Customers.Specifications;
using PetVet.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PetVet.Application.Customers.Features.ViewPets
{
    public class ViewCustomerPetsHandler : IRequestHandler<ViewCustomerPetsQuery, Result<PetsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        public ViewCustomerPetsHandler(IMapper mapper, IRepository<Customer> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<PetsDto>> Handle(ViewCustomerPetsQuery request, CancellationToken cancellationToken)
        {
            var viewCustomerPetsSpec = new ViewCustomerPetsSpecification(request.CustomerId);
            var result = await _repository.ListAsync(viewCustomerPetsSpec, cancellationToken);

            var res = Result<PetsDto>.Success(new PetsDto(new List<PetDto>()));

            return res;
        }
    }
}