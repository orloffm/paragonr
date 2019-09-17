using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paragonr.Persistence.Migrations
{
    public partial class BudgetUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddedById",
                table: "Spendings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BudgetId",
                table: "Spendings",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BudgetId",
                table: "Domains",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "BudgetId",
                table: "Categories",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_AddedById",
                table: "Spendings",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Spendings_BudgetId",
                table: "Spendings",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_BudgetId",
                table: "Domains",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BudgetId",
                table: "Categories",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Budget",
                table: "Categories",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Domain_Budget",
                table: "Domains",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spendings_Users_AddedById",
                table: "Spendings",
                column: "AddedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spending_Budget",
                table: "Spendings",
                column: "BudgetId",
                principalTable: "Budgets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Budget",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Domain_Budget",
                table: "Domains");

            migrationBuilder.DropForeignKey(
                name: "FK_Spendings_Users_AddedById",
                table: "Spendings");

            migrationBuilder.DropForeignKey(
                name: "FK_Spending_Budget",
                table: "Spendings");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_AddedById",
                table: "Spendings");

            migrationBuilder.DropIndex(
                name: "IX_Spendings_BudgetId",
                table: "Spendings");

            migrationBuilder.DropIndex(
                name: "IX_Domains_BudgetId",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Categories_BudgetId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Spendings");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "BudgetId",
                table: "Categories");
        }
    }
}
