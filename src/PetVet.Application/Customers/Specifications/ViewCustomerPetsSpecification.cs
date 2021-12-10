using Ardalis.Specification;
using PetVet.Domain.Entities.Customers;
using System;
using System.Linq;

namespace PetVet.Application.Customers.Specifications
{
    public class ViewCustomerPetsSpecification : Specification<Customer, string>
    {
        public ViewCustomerPetsSpecification(Guid customerId)
        {
            Query
                .Select(x => x.Name.FirstName)
                .Where(x => x.Id == customerId);
        }
    }
}