using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class cloudremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DeleteData(
                table: "Notebooks",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "cloudId",
                table: "Notebooks");

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 13, 59, 28, 981, DateTimeKind.Local).AddTicks(8), new DateTime(2023, 4, 10, 13, 59, 28, 981, DateTimeKind.Local).AddTicks(10) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 13, 59, 28, 980, DateTimeKind.Local).AddTicks(9799), new DateTime(2023, 4, 10, 13, 59, 28, 980, DateTimeKind.Local).AddTicks(9813) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shareStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Clouds",
                columns: new[] { "id", "createdDate", "modifiedDate", "name", "shareStatus" },
                values: new object[] { 1, new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3338), new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3339), "Sample", null });

            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "id", "checkedCount", "cloudId", "createdDate", "imageCount", "modifiedDate", "name", "notebookType", "shareStatus", "textCount", "uncheckedCount" },
                values: new object[] { 1, null, 1, new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3320), null, new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3320), "Sample", null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3303), new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3304) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3160), new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3173) });
        }
    }
}
