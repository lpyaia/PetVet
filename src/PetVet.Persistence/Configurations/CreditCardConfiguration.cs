using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetVet.Domain.Entities.Customers;

namespace PetVet.Persistence.Configurations
{
    internal class CreditCardConfiguration : BaseConfiguration<CreditCard>
    {
        public override void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number).IsRequired();

            builder.Property(x => x.Cvv).IsRequired();

            builder.Property(x => x.ExpirationMonth).IsRequired();

            builder.Property(x => x.ExpirationYear).IsRequired();

            builder
                .HasOne(x => x.Owner)
                .WithMany(x => x.CreditCards)
                .HasForeignKey(x => x.OwnerId);
        }
    }
}