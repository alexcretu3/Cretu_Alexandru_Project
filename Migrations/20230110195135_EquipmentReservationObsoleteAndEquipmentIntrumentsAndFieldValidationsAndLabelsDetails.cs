using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cretu_Alexandru_Project.Migrations
{
    public partial class EquipmentReservationObsoleteAndEquipmentIntrumentsAndFieldValidationsAndLabelsDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezervareEchipament");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Sala",
                type: "decimal(6,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AddColumn<int>(
                name: "EchipamentId",
                table: "Rezervare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Timp",
                table: "Rezervare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instrumente",
                table: "Echipament",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pret",
                table: "Echipament",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_EchipamentId",
                table: "Rezervare",
                column: "EchipamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Echipament_EchipamentId",
                table: "Rezervare",
                column: "EchipamentId",
                principalTable: "Echipament",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Echipament_EchipamentId",
                table: "Rezervare");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_EchipamentId",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "EchipamentId",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "Timp",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "Instrumente",
                table: "Echipament");

            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Echipament");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Sala",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RezervareEchipament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchipamentID = table.Column<int>(type: "int", nullable: false),
                    RezervareID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervareEchipament", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RezervareEchipament_Echipament_EchipamentID",
                        column: x => x.EchipamentID,
                        principalTable: "Echipament",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervareEchipament_Rezervare_RezervareID",
                        column: x => x.RezervareID,
                        principalTable: "Rezervare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RezervareEchipament_EchipamentID",
                table: "RezervareEchipament",
                column: "EchipamentID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervareEchipament_RezervareID",
                table: "RezervareEchipament",
                column: "RezervareID");
        }
    }
}
