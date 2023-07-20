using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class manytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotebookUsers_Notebooks_notebooksid",
                table: "NotebookUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NotebookUsers_Users_usersid",
                table: "NotebookUsers");

            migrationBuilder.RenameColumn(
                name: "usersid",
                table: "NotebookUsers",
                newName: "usersId");

            migrationBuilder.RenameColumn(
                name: "notebooksid",
                table: "NotebookUsers",
                newName: "notebooksId");

            migrationBuilder.RenameIndex(
                name: "IX_NotebookUsers_usersid",
                table: "NotebookUsers",
                newName: "IX_NotebookUsers_usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookUsers_Notebooks_notebooksId",
                table: "NotebookUsers",
                column: "notebooksId",
                principalTable: "Notebooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookUsers_Users_usersId",
                table: "NotebookUsers",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotebookUsers_Notebooks_notebooksId",
                table: "NotebookUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NotebookUsers_Users_usersId",
                table: "NotebookUsers");

            migrationBuilder.RenameColumn(
                name: "usersId",
                table: "NotebookUsers",
                newName: "usersid");

            migrationBuilder.RenameColumn(
                name: "notebooksId",
                table: "NotebookUsers",
                newName: "notebooksid");

            migrationBuilder.RenameIndex(
                name: "IX_NotebookUsers_usersId",
                table: "NotebookUsers",
                newName: "IX_NotebookUsers_usersid");

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookUsers_Notebooks_notebooksid",
                table: "NotebookUsers",
                column: "notebooksid",
                principalTable: "Notebooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotebookUsers_Users_usersid",
                table: "NotebookUsers",
                column: "usersid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
