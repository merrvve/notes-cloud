using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class cloud2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 14, 2, 11, 644, DateTimeKind.Local).AddTicks(6452), new DateTime(2023, 4, 10, 14, 2, 11, 644, DateTimeKind.Local).AddTicks(6453) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 14, 2, 11, 644, DateTimeKind.Local).AddTicks(6328), new DateTime(2023, 4, 10, 14, 2, 11, 644, DateTimeKind.Local).AddTicks(6341) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clouds");

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
    }
}
