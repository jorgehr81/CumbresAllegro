using Microsoft.EntityFrameworkCore.Migrations;

namespace CumbreAllegro2.Migrations
{
    public partial class AddColoniaSector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Colonia",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Colonia");
        }
    }
}
