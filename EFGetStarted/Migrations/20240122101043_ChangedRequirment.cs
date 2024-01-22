using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class ChangedRequirment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TodoId",
                table: "Workers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_TodoId",
                table: "Workers",
                column: "TodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Todos_TodoId",
                table: "Workers",
                column: "TodoId",
                principalTable: "Todos",
                principalColumn: "TodoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Todos_TodoId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_TodoId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "TodoId",
                table: "Workers");
        }
    }
}
