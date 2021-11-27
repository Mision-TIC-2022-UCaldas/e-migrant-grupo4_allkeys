using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMigrant.App.Persistencia.Migrations
{
    public partial class MigraInicial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Migrante",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoIdentificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    numeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paisOrigen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccionElectronica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccionActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    situacionLaboral = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migrante", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Migrante");
        }
    }
}
