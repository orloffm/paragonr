using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;

namespace Paragonr.Persistence.Configurations
{
    public class CurrencyRateConfiguration : EntityBaseConfiguration<CurrencyRate>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<CurrencyRate> builder)
        {
            builder.HasOne(d => d.Base)
               .WithMany()
               .HasForeignKey(d => d.BaseId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_CurrencyRate_BaseCurrency");

            builder.HasOne(d => d.Target)
               .WithMany()
               .HasForeignKey(d => d.TargetId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_CurrencyRate_TargetCurrency");

            builder.Property(d => d.Date)
                .HasColumnType("Date");

            builder.Property(d => d.Rate).IsRequired().HasColumnType("decimal(19, 6)");
        }
    }
}