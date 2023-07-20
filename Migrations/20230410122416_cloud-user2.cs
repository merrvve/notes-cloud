using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class clouduser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCloud_Clouds_cloudId",
                table: "UserCloud");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCloud_Users_userId",
                table: "UserCloud");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCloud",
                table: "UserCloud");

            migrationBuilder.RenameTable(
                name: "UserCloud",
                newName: "UsersClouds");

            migrationBuilder.RenameIndex(
                name: "IX_UserCloud_userId",
                table: "UsersClouds",
                newName: "IX_UsersClouds_userId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCloud_cloudId",
                table: "UsersClouds",
                newName: "IX_UsersClouds_cloudId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersClouds",
                table: "UsersClouds",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersClouds_Clouds_cloudId",
                table: "UsersClouds",
                column: "cloudId",
                principalTable: "Clouds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersClouds_Users_userId",
                table: "UsersClouds",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersClouds_Clouds_cloudId",
                table: "UsersClouds");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersClouds_Users_userId",
                table: "UsersClouds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersClouds",
                table: "UsersClouds");

            migrationBuilder.RenameTable(
                name: "UsersClouds",
                newName: "UserCloud");

            migrationBuilder.RenameIndex(
                name: "IX_UsersClouds_userId",
                table: "UserCloud",
                newName: "IX_UserCloud_userId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersClouds_cloudId",
                table: "UserCloud",
                newName: "IX_UserCloud_cloudId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCloud",
                table: "UserCloud",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCloud_Clouds_cloudId",
                table: "UserCloud",
                column: "cloudId",
                principalTable: "Clouds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCloud_Users_userId",
                table: "UserCloud",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
