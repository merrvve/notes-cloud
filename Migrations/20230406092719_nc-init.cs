using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class ncinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notebooks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notebookType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cloudId = table.Column<int>(type: "int", nullable: true),
                    textCount = table.Column<int>(type: "int", nullable: true),
                    checkedCount = table.Column<int>(type: "int", nullable: true),
                    uncheckedCount = table.Column<int>(type: "int", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notebooks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    textNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notebookId = table.Column<int>(type: "int", nullable: true),
                    stickerNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stickerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noteType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    displayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    emailVerified = table.Column<bool>(type: "bit", nullable: true),
                    isLoggedin = table.Column<bool>(type: "bit", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NotebookUsers",
                columns: table => new
                {
                    notebooksid = table.Column<int>(type: "int", nullable: false),
                    usersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookUsers", x => new { x.notebooksid, x.usersid });
                    table.ForeignKey(
                        name: "FK_NotebookUsers_Notebooks_notebooksid",
                        column: x => x.notebooksid,
                        principalTable: "Notebooks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotebookUsers_Users_usersid",
                        column: x => x.usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotebookUsers_usersid",
                table: "NotebookUsers",
                column: "usersid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotebookUsers");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Notebooks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
