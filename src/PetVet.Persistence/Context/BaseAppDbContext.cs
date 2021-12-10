using Microsoft.EntityFrameworkCore;
using PetVet.Application.Common.Interfaces;
using PetVet.Domain.Common;
using PetVet.Domain.Entities.Assistants;
using PetVet.Domain.Entities.Customers;
using PetVet.Domain.Entities.Vets;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PetVet.Persistence.Context
{
    public class BaseAppDbContext : DbContext, IBaseAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public BaseAppDbContext(DbContextOptions<BaseAppDbContext> options)
            : base(options)
        {
        }

        public BaseAppDbContext(
            DbContextOptions<BaseAppDbContext> options,
            ICurrentUserService currentUserService) : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<Customer> Customer { get; private set; }

        public DbSet<Pet> Pet { get; private set; }

        public DbSet<CreditCard> CreditCard { get; private set; }

        public DbSet<Vet> Vet { get; private set; }

        public DbSet<Assistant> Assistant { get; private set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService?.UserId ?? Guid.Empty;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService?.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}