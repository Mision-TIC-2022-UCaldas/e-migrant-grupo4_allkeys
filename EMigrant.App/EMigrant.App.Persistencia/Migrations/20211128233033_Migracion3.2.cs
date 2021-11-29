using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EMigrant.App.Persistencia.Migrations
{
    public partial class Migracion32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Servicios");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Servicios",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinalizacion",
                table: "Servicios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Servicios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaximoNumMigrantes",
                table: "Servicios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Entidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "FechaFinalizacion",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "MaximoNumMigrantes",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Entidades");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Servicios",
                newName: "Tipo");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
