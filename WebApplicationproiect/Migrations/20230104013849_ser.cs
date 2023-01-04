using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationproiect.Migrations
{
    public partial class ser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pret",
                table: "Serviciu",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Serviciu");
        }
    }
}
