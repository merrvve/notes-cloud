using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class cloudnb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cloudId",
                table: "Notebooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notebooks_cloudId",
                table: "Notebooks",
                column: "cloudId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notebooks_Clouds_cloudId",
                table: "Notebooks",
                column: "cloudId",
                principalTable: "Clouds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notebooks_Clouds_cloudId",
                table: "Notebooks");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropIndex(
                name: "IX_Notebooks_cloudId",
                table: "Notebooks");

            migrationBuilder.DropColumn(
                name: "cloudId",
                table: "Notebooks");
        }
    }
}
