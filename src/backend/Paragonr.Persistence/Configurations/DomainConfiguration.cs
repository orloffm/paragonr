using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;

namespace Paragonr.Persistence.Configurations
{
    public class DomainConfiguration : EntityBaseConfiguration<Domain>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Domain> builder)
        {
            builder.HasOne(d => d.DefaultCategory)
                .WithOne()
                .HasForeignKey<Domain>(d => d.DefaultCategoryId)
                .HasConstraintName("FK_Domain_DefaultCategory");
        }
    }
}