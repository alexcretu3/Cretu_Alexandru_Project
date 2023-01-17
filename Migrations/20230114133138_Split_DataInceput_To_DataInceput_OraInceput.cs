using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cretu_Alexandru_Project.Migrations
{
    public partial class Split_DataInceput_To_DataInceput_OraInceput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataSfarsit",
                table: "Rezervare",
                newName: "OraInceput");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OraInceput",
                table: "Rezervare",
                newName: "DataSfarsit");
        }
    }
}
