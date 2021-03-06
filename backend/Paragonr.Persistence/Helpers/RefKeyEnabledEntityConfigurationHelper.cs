﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Domain.Entities;
using Paragonr.Tools.Domain;

namespace Paragonr.Persistence.Helpers
{
    public static class RefKeyEnabledEntityConfigurationHelper
    {
        public static void ConfigureKey<T>(EntityTypeBuilder<T> builder) where T : EntityBase, IRefKeyEnabledEntity
        {
            builder.HasIndex(d => d.RefKey)
                .IsUnique();

            builder.Property(d => d.RefKey)
                .IsRequired()
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();
        }
    }
}
