using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class onemany3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "notebookId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 8, 11, 53, 45, 25, DateTimeKind.Local).AddTicks(482), new DateTime(2023, 4, 8, 11, 53, 45, 25, DateTimeKind.Local).AddTicks(494) });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_notebookId",
                table: "Notes",
                column: "notebookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notebooks_notebookId",
                table: "Notes",
                column: "notebookId",
                principalTable: "Notebooks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notebooks_notebookId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_notebookId",
                table: "Notes");

            migrationBuilder.AlterColumn<int>(
                name: "notebookId",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 6, 14, 2, 24, 584, DateTimeKind.Local).AddTicks(1489), new DateTime(2023, 4, 6, 14, 2, 24, 584, DateTimeKind.Local).AddTicks(1502) });
        }
    }
}
