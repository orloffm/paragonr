using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;
using Paragonr.Persistence.Helpers;

namespace Paragonr.Persistence.Configurations
{
    public class SpendingConfiguration : EntityBaseConfiguration<Spending>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Spending> builder)
        {
            builder.Property(d => d.Amount)
                .IsRequired()
                .HasColumnType("decimal(19, 6)");

            builder.HasOne(d => d.Category)
                .WithMany(c => c.Spendings)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Spending_Category");

            builder.HasOne(d => d.Currency)
                .WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_Spending_Currency");

            KeyEnabledEntityConfigurationHelper.ConfigureKey(builder);
        }
    }
}