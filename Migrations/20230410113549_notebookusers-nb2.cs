using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class notebookusersnb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_NotebookUsers_notebookUserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_notebookUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "notebookUserId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "notebookId",
                table: "NotebookUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NotebookUsers_notebookId",
                table: "NotebookUsers",
                column: "notebookId");

            migrationBuilder.CreateIndex(
                name: "IX_NotebookUsers_userId",
                table: "NotebookUsers",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookUsers_Notebooks_notebookId",
                table: "NotebookUsers",
                column: "notebookId",
                principalTable: "Notebooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookUsers_Users_userId",
                table: "NotebookUsers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotebookUsers_Notebooks_notebookId",
                table: "NotebookUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NotebookUsers_Users_userId",
                table: "NotebookUsers");

            migrationBuilder.DropIndex(
                name: "IX_NotebookUsers_notebookId",
                table: "NotebookUsers");

            migrationBuilder.DropIndex(
                name: "IX_NotebookUsers_userId",
                table: "NotebookUsers");

            migrationBuilder.DropColumn(
                name: "notebookId",
                table: "NotebookUsers");

            migrationBuilder.AddColumn<int>(
                name: "notebookUserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_notebookUserId",
                table: "Users",
                column: "notebookUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_NotebookUsers_notebookUserId",
                table: "Users",
                column: "notebookUserId",
                principalTable: "NotebookUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
