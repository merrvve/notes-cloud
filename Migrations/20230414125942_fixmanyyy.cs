using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class fixmanyyy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "notebookId",
                table: "UserNotebooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "UserNotebooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserNotebooks_notebookId",
                table: "UserNotebooks",
                column: "notebookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotebooks_userId",
                table: "UserNotebooks",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotebooks_Notebooks_notebookId",
                table: "UserNotebooks",
                column: "notebookId",
                principalTable: "Notebooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotebooks_Users_userId",
                table: "UserNotebooks",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotebooks_Notebooks_notebookId",
                table: "UserNotebooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotebooks_Users_userId",
                table: "UserNotebooks");

            migrationBuilder.DropIndex(
                name: "IX_UserNotebooks_notebookId",
                table: "UserNotebooks");

            migrationBuilder.DropIndex(
                name: "IX_UserNotebooks_userId",
                table: "UserNotebooks");

            migrationBuilder.DropColumn(
                name: "notebookId",
                table: "UserNotebooks");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "UserNotebooks");
        }
    }
}
