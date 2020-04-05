using Microsoft.EntityFrameworkCore.Migrations;

namespace CumbreAllegro2.Migrations
{
    public partial class CasaCalleRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalleId",
                table: "Casas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Casas_CalleId",
                table: "Casas",
                column: "CalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Calles_CalleId",
                table: "Casas",
                column: "CalleId",
                principalTable: "Calles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Calles_CalleId",
                table: "Casas");

            migrationBuilder.DropIndex(
                name: "IX_Casas_CalleId",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "CalleId",
                table: "Casas");
        }
    }
}
