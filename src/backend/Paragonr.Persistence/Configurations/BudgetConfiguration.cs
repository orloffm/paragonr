using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;

namespace Paragonr.Persistence.Configurations
{
    public class BudgetConfiguration : EntityBaseConfiguration<Budget>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Budget> builder)
        {

        }
    }
}