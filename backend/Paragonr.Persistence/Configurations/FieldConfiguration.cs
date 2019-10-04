using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Domain.Entities;
using Paragonr.Persistence.Helpers;

namespace Paragonr.Persistence.Configurations
{
    public sealed class FieldConfiguration : EntityBaseConfiguration<Field>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Field> builder)
        {
            builder.HasOne(d => d.DefaultCategory)
                .WithOne()
                .HasForeignKey<Field>(d => d.DefaultCategoryId)
                .HasConstraintName("FK_Field_DefaultCategory");

            builder.HasOne(m => m.Budget)
                .WithMany(b => b.Fields)
                .HasForeignKey(m => m.BudgetId)
                .HasConstraintName("FK_Field_Budget");

            RefKeyEnabledEntityConfigurationHelper.ConfigureKey(builder);
        }
    }
}
