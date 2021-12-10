using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetVet.Domain.Entities.Customers;

namespace PetVet.Persistence.Configurations
{
    public class CustomerConfiguration : BaseConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Birthday).IsRequired();

            builder.OwnsOne(x => x.Name, x =>
            {
                x.Property(x => x.FirstName)
                 .HasColumnName("FirstName")
                 .HasMaxLength(50)
                 .IsRequired();

                x.Property(x => x.LastName)
                 .HasColumnName("LastName")
                 .HasMaxLength(50)
                 .IsRequired();
            });

            builder.Property(x => x.UserId).IsRequired();

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Customer)
                .HasForeignKey<Customer>(x => x.UserId);
        }
    }
}