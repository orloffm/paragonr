using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Domain.Entities;
using Paragonr.Persistence.Helpers;

namespace Paragonr.Persistence.Configurations
{
    public class CategoryConfiguration : EntityBaseConfiguration<Category>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(d => d.Field)
                .WithMany(p => p.Categories)
                .HasForeignKey(d => d.FieldId)
                .HasConstraintName("FK_Category_Domain");

            RefKeyEnabledEntityConfigurationHelper.ConfigureKey(builder);
        }
    }
}
