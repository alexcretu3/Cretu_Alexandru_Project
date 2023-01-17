using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cretu_Alexandru_Project.Migrations
{
    public partial class Atreia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reprezentant_Trupa_TrupaID",
                table: "Reprezentant");

            migrationBuilder.DropIndex(
                name: "IX_Reprezentant_TrupaID",
                table: "Reprezentant");

            migrationBuilder.DropColumn(
                name: "TrupaID",
                table: "Reprezentant");

            migrationBuilder.AddColumn<int>(
                name: "ReprezentantID",
                table: "Trupa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trupa_ReprezentantID",
                table: "Trupa",
                column: "ReprezentantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trupa_Reprezentant_ReprezentantID",
                table: "Trupa",
                column: "ReprezentantID",
                principalTable: "Reprezentant",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trupa_Reprezentant_ReprezentantID",
                table: "Trupa");

            migrationBuilder.DropIndex(
                name: "IX_Trupa_ReprezentantID",
                table: "Trupa");

            migrationBuilder.DropColumn(
                name: "ReprezentantID",
                table: "Trupa");

            migrationBuilder.AddColumn<int>(
                name: "TrupaID",
                table: "Reprezentant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reprezentant_TrupaID",
                table: "Reprezentant",
                column: "TrupaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reprezentant_Trupa_TrupaID",
                table: "Reprezentant",
                column: "TrupaID",
                principalTable: "Trupa",
                principalColumn: "ID");
        }
    }
}
