using Microsoft.EntityFrameworkCore.Migrations;

namespace EMigrant.App.Persistencia.Migrations
{
    public partial class MigraInicial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Migrante",
                table: "Migrante");

            migrationBuilder.RenameTable(
                name: "Migrante",
                newName: "Migrantes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Migrantes",
                table: "Migrantes",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Migrantes",
                table: "Migrantes");

            migrationBuilder.RenameTable(
                name: "Migrantes",
                newName: "Migrante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Migrante",
                table: "Migrante",
                column: "id");
        }
    }
}
