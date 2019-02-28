using Microsoft.EntityFrameworkCore.Migrations;

namespace SRCalculator.Migrations
{
    public partial class PrivateProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrivateProfile",
                table: "Players",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivateProfile",
                table: "Players");
        }
    }
}
