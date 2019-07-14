using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paragonr.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Category_Domain", "Categories");

            migrationBuilder.DropTable("CurrencyRates");

            migrationBuilder.DropTable("Spendings");

            migrationBuilder.DropTable("Currencies");

            migrationBuilder.DropTable("Domains");

            migrationBuilder.DropTable("Categories");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Currencies",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsoCode = table.Column<string>(maxLength: 3),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Currencies", x => x.Id); }
            );

            migrationBuilder.CreateTable(
                "CurrencyRates",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>("Date"),
                    TargetId = table.Column<long>(),
                    BaseId = table.Column<long>(),
                    Rate = table.Column<decimal>("decimal(19, 6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.Id);
                    table.ForeignKey(
                        "FK_CurrencyRate_BaseCurrency",
                        x => x.BaseId,
                        "Currencies",
                        "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                    table.ForeignKey(
                        "FK_CurrencyRate_TargetCurrency",
                        x => x.TargetId,
                        "Currencies",
                        "Id",
                        onDelete: ReferentialAction.Restrict
                    );
                }
            );

            migrationBuilder.CreateTable(
                "Domains",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DefaultCategoryId = table.Column<long>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Domains", x => x.Id); }
            );

            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DomainId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey("FK_Category_Domain", x => x.DomainId, "Domains", "Id", onDelete: ReferentialAction.Restrict);
                }
            );

            migrationBuilder.CreateTable(
                "Spendings",
                table => new
                {
                    Id = table.Column<long>()
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyId = table.Column<long>(nullable: true),
                    Amount = table.Column<decimal>("decimal(19, 6)"),
                    CategoryId = table.Column<long>(nullable: true),
                    Place = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spendings", x => x.Id);
                    table.ForeignKey("FK_Spending_Category", x => x.CategoryId, "Categories", "Id", onDelete: ReferentialAction.Restrict);
                    table.ForeignKey("FK_Spending_Currency", x => x.CurrencyId, "Currencies", "Id", onDelete: ReferentialAction.Restrict);
                }
            );

            migrationBuilder.CreateIndex("IX_Categories_DomainId", "Categories", "DomainId");

            migrationBuilder.CreateIndex("IX_CurrencyRates_BaseId", "CurrencyRates", "BaseId");

            migrationBuilder.CreateIndex("IX_CurrencyRates_TargetId", "CurrencyRates", "TargetId");

            migrationBuilder.CreateIndex(
                "IX_Domains_DefaultCategoryId",
                "Domains",
                "DefaultCategoryId",
                unique: true,
                filter: "[DefaultCategoryId] IS NOT NULL"
            );

            migrationBuilder.CreateIndex("IX_Spendings_CategoryId", "Spendings", "CategoryId");

            migrationBuilder.CreateIndex("IX_Spendings_CurrencyId", "Spendings", "CurrencyId");

            migrationBuilder.AddForeignKey(
                "FK_Domain_DefaultCategory",
                "Domains",
                "DefaultCategoryId",
                "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict
            );
        }
    }
}