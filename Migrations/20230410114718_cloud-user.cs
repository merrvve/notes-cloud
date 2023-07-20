using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class clouduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCloud",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cloudId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCloud", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserCloud_Clouds_cloudId",
                        column: x => x.cloudId,
                        principalTable: "Clouds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCloud_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCloud_cloudId",
                table: "UserCloud",
                column: "cloudId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCloud_userId",
                table: "UserCloud",
                column: "userId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCloud");
        }
    }
}
