using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;
using Paragonr.Persistence.Helpers;

namespace Paragonr.Persistence.Configurations
{
    public class CategoryConfiguration : EntityBaseConfiguration<Category>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.HasOne(d => d.Domain)
                .WithMany(p => p.Categories)
                .HasForeignKey(d => d.DomainId)
                .HasConstraintName("FK_Category_Domain");

            builder.HasOne(m => m.Budget)
                .WithMany(b => b.Categories)
                .HasForeignKey(m => m.BudgetId)
                .HasConstraintName("FK_Category_Budget");

            KeyEnabledEntityConfigurationHelper.ConfigureKey(builder);
        }
    }
}