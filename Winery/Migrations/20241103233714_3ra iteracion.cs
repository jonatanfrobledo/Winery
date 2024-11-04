using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Winery.Migrations
{
    public partial class _3raiteracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guests",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Catas",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Catas",
                newName: "Fecha");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Guests",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Catas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Catas",
                newName: "Date");
        }
    }
}
