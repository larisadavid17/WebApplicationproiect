using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationproiect.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specializare",
                table: "Angajat",
                newName: "Cursuri");

            migrationBuilder.AddColumn<int>(
                name: "SpecializareID",
                table: "Angajat",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializareName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializare", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_SpecializareID",
                table: "Angajat",
                column: "SpecializareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Angajat_Specializare_SpecializareID",
                table: "Angajat",
                column: "SpecializareID",
                principalTable: "Specializare",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Angajat_Specializare_SpecializareID",
                table: "Angajat");

            migrationBuilder.DropTable(
                name: "Specializare");

            migrationBuilder.DropIndex(
                name: "IX_Angajat_SpecializareID",
                table: "Angajat");

            migrationBuilder.DropColumn(
                name: "SpecializareID",
                table: "Angajat");

            migrationBuilder.RenameColumn(
                name: "Cursuri",
                table: "Angajat",
                newName: "Specializare");
        }
    }
}
