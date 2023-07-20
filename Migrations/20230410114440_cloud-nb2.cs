using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class cloudnb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotebookUsers");

            migrationBuilder.CreateTable(
                name: "NotebookClouds",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cloudId = table.Column<int>(type: "int", nullable: false),
                    notebookId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookClouds", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotebookClouds_Clouds_cloudId",
                        column: x => x.cloudId,
                        principalTable: "Clouds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotebookClouds_Notebooks_notebookId",
                        column: x => x.notebookId,
                        principalTable: "Notebooks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotebookClouds_cloudId",
                table: "NotebookClouds",
                column: "cloudId");

            migrationBuilder.CreateIndex(
                name: "IX_NotebookClouds_notebookId",
                table: "NotebookClouds",
                column: "notebookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotebookClouds");

            migrationBuilder.CreateTable(
                name: "NotebookUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notebookId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotebookUsers", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotebookUsers_Notebooks_notebookId",
                        column: x => x.notebookId,
                        principalTable: "Notebooks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotebookUsers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotebookUsers_notebookId",
                table: "NotebookUsers",
                column: "notebookId");

            migrationBuilder.CreateIndex(
                name: "IX_NotebookUsers_userId",
                table: "NotebookUsers",
                column: "userId");
        }
    }
}
