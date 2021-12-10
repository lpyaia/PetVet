using PetVet.Application.Customers.Features.CustomerRegistration;
using System;

namespace PetVet.Application.UnitTests.Features.Customers.CustomerRegistration
{
    public static class CustomerRegistrationCommandMock
    {
        public static CustomerRegistrationCommand Get(string email,
            string password,
            string firstName,
            string lastName,
            DateTime birthday)
        {
            return new CustomerRegistrationCommand(
                email,
                password,
                firstName,
                lastName,
                birthday);
        }
    }
}