using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;

namespace Paragonr.Persistence.Configurations
{
    public sealed class CurrencyConfiguration : EntityBaseConfiguration<Currency>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(c => c.IsoCode)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(c => c.Symbol)
                .IsRequired()
                .HasMaxLength(3);
        }
    }
}