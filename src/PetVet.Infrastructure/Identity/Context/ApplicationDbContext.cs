using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace PetVet.Infrastructure.Identity.Context
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}