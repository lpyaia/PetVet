using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetVet.Domain.Entities.Users;

namespace PetVet.Persistence.Configurations
{
    internal class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Login).IsRequired();

            builder.Property(x => x.Email).IsRequired();

            builder.Property(x => x.Role).IsRequired();

            builder.Property(x => x.IdentityServerUserId).IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}