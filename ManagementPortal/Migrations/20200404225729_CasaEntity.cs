using Microsoft.EntityFrameworkCore.Migrations;

namespace CumbreAllegro2.Migrations
{
    public partial class CasaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calles_Colonia_ColoniaId",
                table: "Calles");

            migrationBuilder.AlterColumn<int>(
                name: "ColoniaId",
                table: "Calles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Casas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    NombrePropietario = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Telefono1 = table.Column<string>(nullable: true),
                    Telefono2 = table.Column<string>(nullable: true),
                    Telefono3 = table.Column<string>(nullable: true),
                    AccesoCamaras = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Calles_Colonia_ColoniaId",
                table: "Calles",
                column: "ColoniaId",
                principalTable: "Colonia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calles_Colonia_ColoniaId",
                table: "Calles");

            migrationBuilder.DropTable(
                name: "Casas");

            migrationBuilder.AlterColumn<int>(
                name: "ColoniaId",
                table: "Calles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Calles_Colonia_ColoniaId",
                table: "Calles",
                column: "ColoniaId",
                principalTable: "Colonia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
