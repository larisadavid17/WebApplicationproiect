using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationproiect.Migrations
{
    public partial class Spe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeleServiciului = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SpecializareServiciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializareID = table.Column<int>(type: "int", nullable: false),
                    ServiciuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializareServiciu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SpecializareServiciu_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializareServiciu_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializareServiciu_ServiciuID",
                table: "SpecializareServiciu",
                column: "ServiciuID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializareServiciu_SpecializareID",
                table: "SpecializareServiciu",
                column: "SpecializareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializareServiciu");

            migrationBuilder.DropTable(
                name: "Serviciu");
        }
    }
}
