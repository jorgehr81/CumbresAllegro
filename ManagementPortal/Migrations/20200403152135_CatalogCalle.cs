using Microsoft.EntityFrameworkCore.Migrations;

namespace CumbreAllegro2.Migrations
{
    public partial class CatalogCalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    ColoniaId = table.Column<int>(nullable: true),
                    Referencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calles_Colonia_ColoniaId",
                        column: x => x.ColoniaId,
                        principalTable: "Colonia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calles_ColoniaId",
                table: "Calles",
                column: "ColoniaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calles");
        }
    }
}
