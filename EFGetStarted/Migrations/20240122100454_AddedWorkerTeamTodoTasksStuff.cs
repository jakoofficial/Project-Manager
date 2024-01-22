using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFGetStarted.Migrations
{
    /// <inheritdoc />
    public partial class AddedWorkerTeamTodoTasksStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentTodoTodoId",
                table: "Workers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "Todos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentTaskTasksid",
                table: "Teams",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Tasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workers_CurrentTodoTodoId",
                table: "Workers",
                column: "CurrentTodoTodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_WorkerId",
                table: "Todos",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CurrentTaskTasksid",
                table: "Teams",
                column: "CurrentTaskTasksid");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TeamId",
                table: "Tasks",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Teams_TeamId",
                table: "Tasks",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskTasksid",
                table: "Teams",
                column: "CurrentTaskTasksid",
                principalTable: "Tasks",
                principalColumn: "Tasksid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Workers_WorkerId",
                table: "Todos",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Todos_CurrentTodoTodoId",
                table: "Workers",
                column: "CurrentTodoTodoId",
                principalTable: "Todos",
                principalColumn: "TodoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Teams_TeamId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Tasks_CurrentTaskTasksid",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Workers_WorkerId",
                table: "Todos");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Todos_CurrentTodoTodoId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Workers_CurrentTodoTodoId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Todos_WorkerId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CurrentTaskTasksid",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_TeamId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CurrentTodoTodoId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "CurrentTaskTasksid",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Tasks");
        }
    }
}
