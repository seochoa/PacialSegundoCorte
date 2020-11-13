using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Tipodocumeto = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Fechanac = table.Column<DateTime>(nullable: false),
                    Institucion = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Nombreacudiente = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Documento);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    Idvacuna = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Tipovacuna = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Fechavacuna = table.Column<DateTime>(nullable: false),
                    Edadaplicacion = table.Column<int>(nullable: false),
                    PersonaDocumento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.Idvacuna);
                    table.ForeignKey(
                        name: "FK_Vacunas_Personas_PersonaDocumento",
                        column: x => x.PersonaDocumento,
                        principalTable: "Personas",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacunas_PersonaDocumento",
                table: "Vacunas",
                column: "PersonaDocumento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
