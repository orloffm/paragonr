using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Domain.Entities;
using Paragonr.Persistence.Helpers;

namespace Paragonr.Persistence.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            RefKeyEnabledEntityConfigurationHelper.ConfigureKey(builder);
        }
    }
}
