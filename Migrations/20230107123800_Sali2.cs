using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cretu_Alexandru_Project.Migrations
{
    public partial class Sali2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeTrupa",
                table: "Sala",
                newName: "NumeSala");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeSala",
                table: "Sala",
                newName: "NumeTrupa");
        }
    }
}
