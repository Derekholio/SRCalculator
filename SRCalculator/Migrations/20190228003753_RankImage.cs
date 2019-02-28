using Microsoft.EntityFrameworkCore.Migrations;

namespace SRCalculator.Migrations
{
    public partial class RankImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RankImage",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RankImage",
                table: "Players");
        }
    }
}
