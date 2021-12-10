using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetVet.Domain.Entities.Vets;

namespace PetVet.Persistence.Configurations
{
    public class VetConfiguration : BaseConfiguration<Vet>
    {
        public override void Configure(EntityTypeBuilder<Vet> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Vet)
                .HasForeignKey<Vet>(x => x.UserId);
        }
    }
}