using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeUniqueConstraintTaskModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_task_name_user_id",
                table: "task");

            migrationBuilder.CreateIndex(
                name: "IX_task_name_user_id_type_id",
                table: "task",
                columns: new[] { "name", "user_id", "type_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_task_name_user_id_type_id",
                table: "task");

            migrationBuilder.CreateIndex(
                name: "IX_task_name_user_id",
                table: "task",
                columns: new[] { "name", "user_id" },
                unique: true);
        }
    }
}
