using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "imageCount",
                table: "Notebooks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "shareStatus",
                table: "Notebooks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 8, 22, 30, 19, 543, DateTimeKind.Local).AddTicks(2581), new DateTime(2023, 4, 8, 22, 30, 19, 543, DateTimeKind.Local).AddTicks(2594) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageCount",
                table: "Notebooks");

            migrationBuilder.DropColumn(
                name: "shareStatus",
                table: "Notebooks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 8, 11, 53, 45, 25, DateTimeKind.Local).AddTicks(482), new DateTime(2023, 4, 8, 11, 53, 45, 25, DateTimeKind.Local).AddTicks(494) });
        }
    }
}
