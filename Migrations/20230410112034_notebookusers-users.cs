using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class notebookusersusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "notebookUserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NotebookUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookUsers", x => x.id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_NotebookUsers_notebookUserId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "NotebookUsers");

            migrationBuilder.DropIndex(
                name: "IX_Users_notebookUserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "notebookUserId",
                table: "Users");
        }
    }
}
