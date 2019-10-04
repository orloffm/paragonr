using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Domain.Entities;

namespace Paragonr.Persistence.Configurations
{
    public class UserConfiguration : EntityBaseConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {

        }
    }
}
