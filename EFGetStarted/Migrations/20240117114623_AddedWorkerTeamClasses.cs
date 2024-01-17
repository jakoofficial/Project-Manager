using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkerTeamClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamWorker",
                table: "TeamWorker");

            migrationBuilder.RenameTable(
                name: "TeamWorker",
                newName: "TeamWorkers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamWorkers",
                table: "TeamWorkers",
                columns: new[] { "TeamId", "WorkerId" });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.WorkerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamWorkers_WorkerId",
                table: "TeamWorkers",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Team_TeamId",
                table: "TeamWorkers",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamWorkers_Worker_WorkerId",
                table: "TeamWorkers",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Team_TeamId",
                table: "TeamWorkers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamWorkers_Worker_WorkerId",
                table: "TeamWorkers");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamWorkers",
                table: "TeamWorkers");

            migrationBuilder.DropIndex(
                name: "IX_TeamWorkers_WorkerId",
                table: "TeamWorkers");

            migrationBuilder.RenameTable(
                name: "TeamWorkers",
                newName: "TeamWorker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamWorker",
                table: "TeamWorker",
                columns: new[] { "TeamId", "WorkerId" });
        }
    }
}
