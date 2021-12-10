using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetVet.Application.Common.Models;
using PetVet.Application.Customers.Dtos;
using PetVet.Application.Customers.Features.ViewPets;
using System;
using System.Threading.Tasks;

namespace PetVet.Web.Controllers
{
    [Route("api/customer")]
    //[Authorize(Roles = "Customer")]
    [ApiController]
    public class Customer : ControllerBase
    {
        private readonly IMediator _mediator;

        public Customer(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/pets")]
        public async Task<ActionResult<Result<PetsDto>>> GetPets(Guid id)
        {
            return await _mediator.Send(new ViewCustomerPetsQuery { CustomerId = Guid.NewGuid() });
        }
    }
}