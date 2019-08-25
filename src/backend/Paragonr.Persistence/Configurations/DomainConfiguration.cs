using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;
using Paragonr.Persistence.Helpers;

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

            builder.HasOne(m => m.Budget)
                .WithMany(b => b.Domains)
                .HasForeignKey(m => m.BudgetId)
                .HasConstraintName("FK_Domain_Budget");

            KeyEnabledEntityConfigurationHelper.ConfigureKey(builder);
        }
    }
}