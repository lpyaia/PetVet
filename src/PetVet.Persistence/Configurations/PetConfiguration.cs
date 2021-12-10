using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetVet.Domain.Entities.Customers;

namespace PetVet.Persistence.Configurations
{
    internal class PetConfiguration : BaseConfiguration<Pet>
    {
        public override void Configure(EntityTypeBuilder<Pet> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Name, x =>
            {
                x.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired();
                x.Property(x => x.LastName).HasColumnName("LastName").IsRequired(false);
            });

            builder
                .HasOne(x => x.Tutor)
                .WithMany(x => x.Pets)
                .HasForeignKey(x => x.TutorId);
        }
    }
}