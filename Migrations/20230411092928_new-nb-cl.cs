using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class newnbcl : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Notebooks_cloudId",
                table: "Notebooks");

            migrationBuilder.DropColumn(
                name: "cloudId",
                table: "Notebooks");
        }
    }
}
