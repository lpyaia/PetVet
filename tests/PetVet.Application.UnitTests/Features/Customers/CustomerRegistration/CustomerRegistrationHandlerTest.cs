using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using PetVet.Application.Common.Interfaces;
using PetVet.Application.Common.Models;
using PetVet.Application.Customers.Features.CustomerRegistration;
using PetVet.Application.UnitTests.Helpers;
using PetVet.Domain.Entities.Users;
using PetVet.Persistence.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PetVet.Application.UnitTests.Features.Customers.CustomerRegistration
{
    public class CustomerRegistrationHandlerTest
    {
        [Fact]
        public async Task GivenACustomerRegistrationCommand_WhenUserNameDoesNotExists_ThenShouldCreateANewUser()
        {
            // arrange
            var identityService = Substitute.For<IIdentityService>();
            var logger = Substitute.For<ILogger<CustomerRegistrationHandler>>();
            var mediator = Substitute.For<IMediator>();
            var dbContext = BaseAppDbContextInMemoryFactory.CreateInMemoryDb();
            var repository = new Repository<User>(dbContext);

            var command = CustomerRegistrationCommandMock
                .Get("user@test.com", "Bla!123", "john", "doe", new DateTime(1920, 1, 1));

            var handler = new CustomerRegistrationHandler(
                identityService,
                logger,
                repository,
                mediator);

            identityService
                .CreateUserAsync(Arg.Any<string>(), Arg.Any<string>())
                .Returns(x => (Result.Success(), Guid.NewGuid()));

            identityService
                .AddUserToRoleAsync(Arg.Any<Guid>(), Arg.Any<string>())
                .Returns(x => Result.Success());

            // act
            var result = await handler.Handle(command, CancellationToken.None);

            // assert
            result.Succeeded.Should().BeTrue();
        }
    }
}