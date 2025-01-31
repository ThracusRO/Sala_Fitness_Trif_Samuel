using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sala_Fitness_Trif_Samuel.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specializare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipAbonament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAbonament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Antrenor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializareID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Antrenor_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Abonament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipAbonamentID = table.Column<int>(type: "int", nullable: true),
                    Pret = table.Column<int>(type: "int", nullable: true),
                    Durata = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonament", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Abonament_TipAbonament_TipAbonamentID",
                        column: x => x.TipAbonamentID,
                        principalTable: "TipAbonament",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasterii = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbonamentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Utilizator_Abonament_AbonamentID",
                        column: x => x.AbonamentID,
                        principalTable: "Abonament",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizatorID = table.Column<int>(type: "int", nullable: true),
                    AntrenorID = table.Column<int>(type: "int", nullable: true),
                    DataProgramare = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DurataMinute = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Antrenor_AntrenorID",
                        column: x => x.AntrenorID,
                        principalTable: "Antrenor",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Utilizator_UtilizatorID",
                        column: x => x.UtilizatorID,
                        principalTable: "Utilizator",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonament_TipAbonamentID",
                table: "Abonament",
                column: "TipAbonamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Antrenor_SpecializareID",
                table: "Antrenor",
                column: "SpecializareID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_AntrenorID",
                table: "Programare",
                column: "AntrenorID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_UtilizatorID",
                table: "Programare",
                column: "UtilizatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Utilizator_AbonamentID",
                table: "Utilizator",
                column: "AbonamentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");

            migrationBuilder.DropTable(
                name: "Antrenor");

            migrationBuilder.DropTable(
                name: "Utilizator");

            migrationBuilder.DropTable(
                name: "Specializare");

            migrationBuilder.DropTable(
                name: "Abonament");

            migrationBuilder.DropTable(
                name: "TipAbonament");
        }
    }
}
