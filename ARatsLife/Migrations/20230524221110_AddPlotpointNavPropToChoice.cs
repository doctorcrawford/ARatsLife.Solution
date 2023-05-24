using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARatsLife.Migrations
{
    public partial class AddPlotpointNavPropToChoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Choices_PlotpointId",
                table: "Choices",
                column: "PlotpointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Plotpoints_PlotpointId",
                table: "Choices",
                column: "PlotpointId",
                principalTable: "Plotpoints",
                principalColumn: "PlotpointId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Plotpoints_PlotpointId",
                table: "Choices");

            migrationBuilder.DropIndex(
                name: "IX_Choices_PlotpointId",
                table: "Choices");
        }
    }
}
