using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRequirmentWithTeam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tasksid",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Tasksid",
                table: "Teams",
                column: "Tasksid");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tasks_Tasksid",
                table: "Teams",
                column: "Tasksid",
                principalTable: "Tasks",
                principalColumn: "Tasksid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_Tasksid",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Tasksid",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Tasksid",
                table: "Teams");
        }
    }
}
