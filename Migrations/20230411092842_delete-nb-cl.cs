using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class deletenbcl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotebookClouds");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
