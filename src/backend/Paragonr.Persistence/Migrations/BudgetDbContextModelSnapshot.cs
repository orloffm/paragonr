﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Paragonr.Persistence.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    internal class BudgetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity(
                "Paragonr.Entities.Category",
                b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DomainId");

                    b.HasKey("Id");

                    b.HasIndex("DomainId");

                    b.ToTable("Categories");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.Currency",
                b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.CurrencyRate",
                b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BaseId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(19, 6)");

                    b.Property<long>("TargetId");

                    b.HasKey("Id");

                    b.HasIndex("BaseId");

                    b.HasIndex("TargetId");

                    b.ToTable("CurrencyRates");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.Domain",
                b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("DefaultCategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DefaultCategoryId")
                        .IsUnique()
                        .HasFilter("[DefaultCategoryId] IS NOT NULL");

                    b.ToTable("Domains");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.Spending",
                b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19, 6)");

                    b.Property<long?>("CategoryId");

                    b.Property<long?>("CurrencyId");

                    b.Property<string>("Note");

                    b.Property<string>("Place");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Spendings");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.Category",
                b =>
                {
                    b.HasOne("Paragonr.Entities.Domain", "Domain")
                        .WithMany("Categories")
                        .HasForeignKey("DomainId")
                        .HasConstraintName("FK_Category_Domain");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.CurrencyRate",
                b =>
                {
                    b.HasOne("Paragonr.Entities.Currency", "Base")
                        .WithMany()
                        .HasForeignKey("BaseId")
                        .HasConstraintName("FK_CurrencyRate_BaseCurrency");

                    b.HasOne("Paragonr.Entities.Currency", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .HasConstraintName("FK_CurrencyRate_TargetCurrency");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.Domain",
                b =>
                {
                    b.HasOne("Paragonr.Entities.Category", "DefaultCategory")
                        .WithOne()
                        .HasForeignKey("Paragonr.Entities.Domain", "DefaultCategoryId")
                        .HasConstraintName("FK_Domain_DefaultCategory");
                }
            );

            modelBuilder.Entity(
                "Paragonr.Entities.Spending",
                b =>
                {
                    b.HasOne("Paragonr.Entities.Category", "Category")
                        .WithMany("Spendings")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Spending_Category");

                    b.HasOne("Paragonr.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("FK_Spending_Currency");
                }
            );
#pragma warning restore 612, 618
        }
    }
}