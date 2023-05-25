using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLife.Migrations
{
    public partial class AddStoryPositionToPlotpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoryPosition",
                table: "Plotpoints",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoryPosition",
                table: "Plotpoints");
        }
    }
}
