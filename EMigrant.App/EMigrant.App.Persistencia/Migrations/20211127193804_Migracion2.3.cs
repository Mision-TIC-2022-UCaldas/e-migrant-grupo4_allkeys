using Microsoft.EntityFrameworkCore.Migrations;

namespace EMigrant.App.Persistencia.Migrations
{
    public partial class Migracion23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Familias");

            migrationBuilder.CreateTable(
                name: "Parientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamiliarId = table.Column<int>(type: "int", nullable: false),
                    GrupoFamiliarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parientes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Parientes_Familiares_GrupoFamiliarId",
                        column: x => x.GrupoFamiliarId,
                        principalTable: "Familiares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parientes_GrupoFamiliarId",
                table: "Parientes",
                column: "GrupoFamiliarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parientes");

            migrationBuilder.CreateTable(
                name: "Familias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamiliarId = table.Column<int>(type: "int", nullable: false),
                    GrupoFamiliarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familias", x => x.id);
                    table.ForeignKey(
                        name: "FK_Familias_Familiares_GrupoFamiliarId",
                        column: x => x.GrupoFamiliarId,
                        principalTable: "Familiares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Familias_GrupoFamiliarId",
                table: "Familias",
                column: "GrupoFamiliarId");
        }
    }
}
