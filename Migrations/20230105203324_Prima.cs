using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cretu_Alexandru_Project.Migrations
{
    public partial class Prima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Echipament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipEchipament = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echipament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeTrupa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suprafata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trupa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeTrupa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numarPersoane = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trupa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reprezentant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrupaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reprezentant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reprezentant_Trupa_TrupaID",
                        column: x => x.TrupaID,
                        principalTable: "Trupa",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Rezervare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaID = table.Column<int>(type: "int", nullable: true),
                    TrupaID = table.Column<int>(type: "int", nullable: true),
                    DataInceput = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSfarsit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervare_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rezervare_Trupa_TrupaID",
                        column: x => x.TrupaID,
                        principalTable: "Trupa",
                        principalColumn: "ID");
                });

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
                name: "IX_Reprezentant_TrupaID",
                table: "Reprezentant",
                column: "TrupaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_SalaID",
                table: "Rezervare",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_TrupaID",
                table: "Rezervare",
                column: "TrupaID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervareEchipament_EchipamentID",
                table: "RezervareEchipament",
                column: "EchipamentID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervareEchipament_RezervareID",
                table: "RezervareEchipament",
                column: "RezervareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reprezentant");

            migrationBuilder.DropTable(
                name: "RezervareEchipament");

            migrationBuilder.DropTable(
                name: "Echipament");

            migrationBuilder.DropTable(
                name: "Rezervare");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Trupa");
        }
    }
}
