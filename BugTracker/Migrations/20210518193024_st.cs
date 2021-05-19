using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Migrations
{
    public partial class st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrentStatus",
                table: "Improvements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStatus",
                table: "Improvements");
        }
    }
}
