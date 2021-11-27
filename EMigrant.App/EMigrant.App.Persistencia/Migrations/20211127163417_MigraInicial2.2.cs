using Microsoft.EntityFrameworkCore.Migrations;

namespace EMigrant.App.Persistencia.Migrations
{
    public partial class MigraInicial22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amigos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmigoId = table.Column<int>(type: "int", nullable: false),
                    GrupoFamiliarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Amigos_Familiares_GrupoFamiliarId",
                        column: x => x.GrupoFamiliarId,
                        principalTable: "Familiares",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Amigos_GrupoFamiliarId",
                table: "Amigos",
                column: "GrupoFamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Familias_GrupoFamiliarId",
                table: "Familias",
                column: "GrupoFamiliarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amigos");

            migrationBuilder.DropTable(
                name: "Familias");
        }
    }
}
