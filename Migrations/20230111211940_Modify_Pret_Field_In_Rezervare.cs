using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cretu_Alexandru_Project.Migrations
{
    public partial class Modify_Pret_Field_In_Rezervare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Echipament_EchipamentId",
                table: "Rezervare");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Sala_SalaID",
                table: "Rezervare");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Trupa_TrupaID",
                table: "Rezervare");

            migrationBuilder.DropForeignKey(
                name: "FK_Trupa_Reprezentant_ReprezentantID",
                table: "Trupa");

            migrationBuilder.AlterColumn<int>(
                name: "ReprezentantID",
                table: "Trupa",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeTrupa",
                table: "Trupa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Suprafata",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Sala",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeSala",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Locatie",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TrupaID",
                table: "Rezervare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Timp",
                table: "Rezervare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalaID",
                table: "Rezervare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EchipamentId",
                table: "Rezervare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pret",
                table: "Rezervare",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prenume",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Echipament_EchipamentId",
                table: "Rezervare",
                column: "EchipamentId",
                principalTable: "Echipament",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Sala_SalaID",
                table: "Rezervare",
                column: "SalaID",
                principalTable: "Sala",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Trupa_TrupaID",
                table: "Rezervare",
                column: "TrupaID",
                principalTable: "Trupa",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trupa_Reprezentant_ReprezentantID",
                table: "Trupa",
                column: "ReprezentantID",
                principalTable: "Reprezentant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Echipament_EchipamentId",
                table: "Rezervare");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Sala_SalaID",
                table: "Rezervare");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Trupa_TrupaID",
                table: "Rezervare");

            migrationBuilder.DropForeignKey(
                name: "FK_Trupa_Reprezentant_ReprezentantID",
                table: "Trupa");

            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Rezervare");

            migrationBuilder.AlterColumn<int>(
                name: "ReprezentantID",
                table: "Trupa",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NumeTrupa",
                table: "Trupa",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Suprafata",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Pret",
                table: "Sala",
                type: "decimal(6,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<string>(
                name: "NumeSala",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Locatie",
                table: "Sala",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TrupaID",
                table: "Rezervare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Timp",
                table: "Rezervare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalaID",
                table: "Rezervare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EchipamentId",
                table: "Rezervare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prenume",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reprezentant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Echipament_EchipamentId",
                table: "Rezervare",
                column: "EchipamentId",
                principalTable: "Echipament",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Sala_SalaID",
                table: "Rezervare",
                column: "SalaID",
                principalTable: "Sala",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Trupa_TrupaID",
                table: "Rezervare",
                column: "TrupaID",
                principalTable: "Trupa",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trupa_Reprezentant_ReprezentantID",
                table: "Trupa",
                column: "ReprezentantID",
                principalTable: "Reprezentant",
                principalColumn: "ID");
        }
    }
}
