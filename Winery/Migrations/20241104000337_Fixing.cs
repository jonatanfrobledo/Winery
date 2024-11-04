using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Winery.Migrations
{
    public partial class Fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Catas_CataId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_CataId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "CataId",
                table: "Wines");

            migrationBuilder.AddColumn<int>(
                name: "CataId",
                table: "Catas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CataWine",
                columns: table => new
                {
                    CatasId = table.Column<int>(type: "INTEGER", nullable: false),
                    VinosId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataWine", x => new { x.CatasId, x.VinosId });
                    table.ForeignKey(
                        name: "FK_CataWine_Catas_CatasId",
                        column: x => x.CatasId,
                        principalTable: "Catas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CataWine_Wines_VinosId",
                        column: x => x.VinosId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catas_CataId",
                table: "Catas",
                column: "CataId");

            migrationBuilder.CreateIndex(
                name: "IX_CataWine_VinosId",
                table: "CataWine",
                column: "VinosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catas_Catas_CataId",
                table: "Catas",
                column: "CataId",
                principalTable: "Catas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catas_Catas_CataId",
                table: "Catas");

            migrationBuilder.DropTable(
                name: "CataWine");

            migrationBuilder.DropIndex(
                name: "IX_Catas_CataId",
                table: "Catas");

            migrationBuilder.DropColumn(
                name: "CataId",
                table: "Catas");

            migrationBuilder.AddColumn<int>(
                name: "CataId",
                table: "Wines",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wines_CataId",
                table: "Wines",
                column: "CataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Catas_CataId",
                table: "Wines",
                column: "CataId",
                principalTable: "Catas",
                principalColumn: "Id");
        }
    }
}
