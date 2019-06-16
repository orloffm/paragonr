using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;

namespace Paragonr.Persistence.Configurations
{
    public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            ConfigureBase(builder);
            ConfigureEntity(builder);
        }
        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);

        private void ConfigureBase(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}