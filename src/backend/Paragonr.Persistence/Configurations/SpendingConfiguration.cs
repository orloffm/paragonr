using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;

namespace Paragonr.Persistence.Configurations
{
    public class SpendingConfiguration : EntityBaseConfiguration<Spending>
    {
        [Column(TypeName = "decimal(18, 6)")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public long? CategoryId { get; set; }

        [ForeignKey(nameof(CurrencyId))]
        public Currency Currency { get; set; }

        public long? CurrencyId { get; set; }

        public string Note { get; set; }

        public string Place { get; set; }

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
        }
    }
}