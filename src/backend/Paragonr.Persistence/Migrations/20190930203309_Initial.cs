using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paragonr.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsoCode = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyRates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(19, 6)", nullable: false),
                    TargetId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_BaseCurrency",
                        column: x => x.BaseId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyRate_TargetCurrency",
                        column: x => x.TargetId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    BudgetId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    IsManager = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => new { x.BudgetId, x.UserId });
                    table.UniqueConstraint("AK_Memberships_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Budget",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainId = table.Column<long>(nullable: true),
                    BudgetId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RefKey = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Budget",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<long>(nullable: false),
                    DefaultCategoryId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RefKey = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Budget",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Field_DefaultCategory",
                        column: x => x.DefaultCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spendings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(19, 6)", nullable: false),
                    CategoryId = table.Column<long>(nullable: true),
                    CurrencyId = table.Column<long>(nullable: true),
                    BudgetId = table.Column<long>(nullable: true),
                    AddedById = table.Column<long>(nullable: false),
                    RefKey = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    Note = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spendings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spendings_Users_AddedById",
                        column: x => x.AddedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Spending_Budget",
                        column: x => x.BudgetId,
                        principalTable: "Budgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spending_Category",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spending_Currency",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BudgetId",
                table: "Categories",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DomainId",
                table: "Categories",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RefKey",
                table: "Categories",
                column: "RefKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_BaseId",
                table: "CurrencyRates",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyRates_TargetId",
                table: "CurrencyRates",
                column: "TargetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_BudgetId",
                table: "Fields",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_DefaultCategoryId",
                table: "Fields",
                column: "DefaultCategoryId",
                unique: true,
                filter: "[DefaultCategoryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_RefKey",
                table: "Fields",
                column: "RefKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_AddedById",
                table: "Spendings",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_BudgetId",
                table: "Spendings",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_CategoryId",
                table: "Spendings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_CurrencyId",
                table: "Spendings",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_RefKey",
                table: "Spendings",
                column: "RefKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Domain",
                table: "Categories",
                column: "DomainId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Budget",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Field_Budget",
                table: "Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Domain",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "CurrencyRates");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Spendings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
