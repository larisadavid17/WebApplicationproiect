using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationproiect.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecializareName",
                table: "Specializare",
                newName: "DenumireSpecializare");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DenumireSpecializare",
                table: "Specializare",
                newName: "SpecializareName");
        }
    }
}
