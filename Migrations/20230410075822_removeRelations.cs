using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class removeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotebookUsers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 10, 58, 22, 391, DateTimeKind.Local).AddTicks(7927), new DateTime(2023, 4, 10, 10, 58, 22, 391, DateTimeKind.Local).AddTicks(7942) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotebookUsers",
                columns: table => new
                {
                    notebooksId = table.Column<int>(type: "int", nullable: false),
                    usersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookUsers", x => new { x.notebooksId, x.usersId });
                    table.ForeignKey(
                        name: "FK_NotebookUsers_Notebooks_notebooksId",
                        column: x => x.notebooksId,
                        principalTable: "Notebooks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotebookUsers_Users_usersId",
                        column: x => x.usersId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 8, 22, 30, 19, 543, DateTimeKind.Local).AddTicks(2581), new DateTime(2023, 4, 8, 22, 30, 19, 543, DateTimeKind.Local).AddTicks(2594) });

            migrationBuilder.CreateIndex(
                name: "IX_NotebookUsers_usersId",
                table: "NotebookUsers",
                column: "usersId");
        }
    }
}
