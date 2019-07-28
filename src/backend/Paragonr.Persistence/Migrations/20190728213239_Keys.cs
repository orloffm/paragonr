using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paragonr.Persistence.Migrations
{
    public partial class Keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                table: "Spendings",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "Domains",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<Guid>(
                name: "Key",
                table: "Categories",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.CreateIndex(
                name: "IX_Domains_Key",
                table: "Domains",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Key",
                table: "Categories",
                column: "Key",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Domains_Key",
                table: "Domains");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Key",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Domains");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "Key",
                table: "Spendings",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWID()");
        }
    }
}
