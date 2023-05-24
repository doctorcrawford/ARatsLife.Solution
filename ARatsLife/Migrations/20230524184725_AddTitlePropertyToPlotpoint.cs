using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLife.Migrations
{
    public partial class AddTitlePropertyToPlotpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Plotpoints",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Plotpoints");
        }
    }
}
