using Microsoft.EntityFrameworkCore.Migrations;

namespace EMigrant.App.Persistencia.Migrations
{
    public partial class MigraInicial17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoFamiliarId",
                table: "Migrantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Familiares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiares", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Migrantes_GrupoFamiliarId",
                table: "Migrantes",
                column: "GrupoFamiliarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Migrantes_Familiares_GrupoFamiliarId",
                table: "Migrantes",
                column: "GrupoFamiliarId",
                principalTable: "Familiares",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migrantes_Familiares_GrupoFamiliarId",
                table: "Migrantes");

            migrationBuilder.DropTable(
                name: "Familiares");

            migrationBuilder.DropIndex(
                name: "IX_Migrantes_GrupoFamiliarId",
                table: "Migrantes");

            migrationBuilder.DropColumn(
                name: "GrupoFamiliarId",
                table: "Migrantes");
        }
    }
}
