﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Entities;

namespace Paragonr.Persistence.Configurations
{
    public class MembershipConfiguration : EntityBaseConfiguration<Membership>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Membership> builder)
        {
            builder.HasOne(m => m.Budget)
                .WithMany(b => b.Memberships)
                .HasForeignKey(m => m.BudgetId)
                .HasConstraintName("FK_Membership_Budget");

            builder.HasOne(m => m.User)
                .WithMany(b => b.Memberships)
                .HasForeignKey(m => m.UserId)
                .HasConstraintName("FK_Membership_User");
        }
    }
}