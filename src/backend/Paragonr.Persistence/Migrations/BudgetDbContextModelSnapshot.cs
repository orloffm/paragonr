﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Paragonr.Persistence;

namespace Paragonr.Persistence.Migrations
{
    [DbContext(typeof(BudgetDbContext))]
    partial class BudgetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Paragonr.Domain.Entities.Budget", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("FieldId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("RefKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("RefKey")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Currency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasColumnType("character varying(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("character varying(3)")
                        .HasMaxLength(3);

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.CurrencyRate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("BaseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(19, 6)");

                    b.Property<long>("TargetId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BaseId");

                    b.HasIndex("TargetId");

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Field", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("BudgetId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DefaultCategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("RefKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("DefaultCategoryId")
                        .IsUnique();

                    b.HasIndex("RefKey")
                        .IsUnique();

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Membership", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("BudgetId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsManager")
                        .HasColumnType("boolean");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("BudgetId", "UserId")
                        .IsUnique();

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Spending", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("AddedById")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19, 6)");

                    b.Property<long?>("BudgetId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Place")
                        .HasColumnType("text");

                    b.Property<Guid>("RefKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("BudgetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("RefKey")
                        .IsUnique();

                    b.ToTable("Spendings");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Category", b =>
                {
                    b.HasOne("Paragonr.Domain.Entities.Field", "Field")
                        .WithMany("Categories")
                        .HasForeignKey("FieldId")
                        .HasConstraintName("FK_Category_Domain");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.CurrencyRate", b =>
                {
                    b.HasOne("Paragonr.Domain.Entities.Currency", "Base")
                        .WithMany()
                        .HasForeignKey("BaseId")
                        .HasConstraintName("FK_CurrencyRate_BaseCurrency")
                        .IsRequired();

                    b.HasOne("Paragonr.Domain.Entities.Currency", "Target")
                        .WithMany()
                        .HasForeignKey("TargetId")
                        .HasConstraintName("FK_CurrencyRate_TargetCurrency")
                        .IsRequired();
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Field", b =>
                {
                    b.HasOne("Paragonr.Domain.Entities.Budget", "Budget")
                        .WithMany("Fields")
                        .HasForeignKey("BudgetId")
                        .HasConstraintName("FK_Field_Budget")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paragonr.Domain.Entities.Category", "DefaultCategory")
                        .WithOne()
                        .HasForeignKey("Paragonr.Domain.Entities.Field", "DefaultCategoryId")
                        .HasConstraintName("FK_Field_DefaultCategory");
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Membership", b =>
                {
                    b.HasOne("Paragonr.Domain.Entities.Budget", "Budget")
                        .WithMany("Memberships")
                        .HasForeignKey("BudgetId")
                        .HasConstraintName("FK_Membership_Budget")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paragonr.Domain.Entities.User", "User")
                        .WithMany("Memberships")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Membership_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paragonr.Domain.Entities.Spending", b =>
                {
                    b.HasOne("Paragonr.Domain.Entities.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Paragonr.Domain.Entities.Budget", "Budget")
                        .WithMany("Spendings")
                        .HasForeignKey("BudgetId")
                        .HasConstraintName("FK_Spending_Budget");

                    b.HasOne("Paragonr.Domain.Entities.Category", "Category")
                        .WithMany("Spendings")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Spending_Category");

                    b.HasOne("Paragonr.Domain.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("FK_Spending_Currency");
                });
#pragma warning restore 612, 618
        }
    }
}
