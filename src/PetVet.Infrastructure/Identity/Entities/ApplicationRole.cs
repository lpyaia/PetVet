using Microsoft.AspNetCore.Identity;
using System;

namespace PetVet.Infrastructure.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string role) : base(role)
        {
        }
    }
}