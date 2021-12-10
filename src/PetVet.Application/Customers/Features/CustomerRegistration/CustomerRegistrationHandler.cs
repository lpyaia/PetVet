using MediatR;
using Microsoft.Extensions.Logging;
using PetVet.Application.Common.Interfaces;
using PetVet.Application.Common.Models;
using PetVet.Domain.Common;
using PetVet.Domain.Entities.Customers;
using PetVet.Domain.Entities.Users;
using Polly;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetVet.Application.Customers.Features.CustomerRegistration
{
    public class CustomerRegistrationHandler : IRequestHandler<CustomerRegistrationCommand, Result>
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<CustomerRegistrationHandler> _logger;
        private readonly IRepository<User> _repository;
        private readonly IMediator _mediator;

        public CustomerRegistrationHandler(IIdentityService identityService,
            ILogger<CustomerRegistrationHandler> logger,
            IRepository<User> repository,
            IMediator mediator)
        {
            _identityService = identityService;
            _logger = logger;
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<Result> Handle(CustomerRegistrationCommand request, CancellationToken cancellationToken)
        {
            Result result = Result.Success();

            (var creationUserResult, var userId) = await _identityService.CreateUserAsync(request.Email, request.Password);
            var assigningUserToRoleResult = await _identityService.AddUserToRoleAsync(userId, Role.Customer);

            if (creationUserResult.Succeeded && assigningUserToRoleResult.Succeeded)
            {
                var customer =
                    new Customer(request.FirstName, request.LastName, request.Birthday);

                var user =
                    new User(request.Email, request.Email, Role.Customer, userId);

                user.AssignCustomer(customer);

                await _repository.AddAsync(user);

                var retryPolicy = Policy
                                    .Handle<Exception>()
                                    .RetryAsync(3, async (ex, attempt) => await Task.Delay(500));

                var fallbackPolicy = Policy
                                        .Handle<Exception>()
                                        .FallbackAsync(async (ct) =>
                                        {
                                            await _mediator.Publish(new { });
                                            result = Result.Failure($"Error while registrying Customer {request.FirstName} {request.LastName}.");
                                        });

                await fallbackPolicy
                    .WrapAsync(retryPolicy)
                    .ExecuteAsync(async () => { await _repository.SaveChangesAsync(); });
            }

            else
            {
                result = Result.Failure($"Error while creating user identity");
            }

            return result;
        }
    }
}