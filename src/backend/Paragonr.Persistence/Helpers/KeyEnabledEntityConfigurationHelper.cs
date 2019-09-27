﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paragonr.Domain.Entities;
using Paragonr.Tools;

namespace Paragonr.Persistence.Helpers
{
    public static class KeyEnabledEntityConfigurationHelper
    {
        public static void ConfigureKey<T>(EntityTypeBuilder<T> builder) where T : EntityBase, IKeyEnabledEntity
        {
            builder.HasIndex(d => d.Key)
                .IsUnique();

            builder.Property(d => d.Key)
                .IsRequired()
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();
        }
    }
}