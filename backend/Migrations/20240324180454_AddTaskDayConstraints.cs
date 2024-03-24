using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskDayConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_task_day_task_id",
                table: "task_day");

            migrationBuilder.CreateIndex(
                name: "IX_task_day_task_id_day",
                table: "task_day",
                columns: new[] { "task_id", "day" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_task_day_task_id_day",
                table: "task_day");

            migrationBuilder.CreateIndex(
                name: "IX_task_day_task_id",
                table: "task_day",
                column: "task_id");
        }
    }
}
