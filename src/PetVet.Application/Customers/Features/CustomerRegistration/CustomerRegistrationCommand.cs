using MediatR;
using PetVet.Application.Common.Models;
using PetVet.Application.Common.Security;
using System;

namespace PetVet.Application.Customers.Features.CustomerRegistration
{
    [SecretContent]
    public record CustomerRegistrationCommand(string Email,
        string Password,
        string FirstName,
        string LastName,
        DateTime Birthday) : IRequest<Result>;
}