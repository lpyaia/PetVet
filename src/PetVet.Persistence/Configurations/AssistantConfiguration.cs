using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetVet.Domain.Entities.Assistants;

namespace PetVet.Persistence.Configurations
{
    public class AssistantConfiguration : BaseConfiguration<Assistant>
    {
        public override void Configure(EntityTypeBuilder<Assistant> builder)
        {
            base.Configure(builder);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Assistant)
                .HasForeignKey<Assistant>(x => x.UserId);
        }
    }
}