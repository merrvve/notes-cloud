using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class cloud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "cloudId",
                table: "Notebooks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shareStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Clouds",
                columns: new[] { "id", "createdDate", "modifiedDate", "name", "shareStatus" },
                values: new object[] { 1, new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3338), new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3339), "Sample", null });

            migrationBuilder.UpdateData(
                table: "Notebooks",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "cloudId", "createdDate", "modifiedDate" },
                values: new object[] { 1, new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3320), new DateTime(2023, 4, 10, 13, 45, 21, 852, DateTimeKind.Local).AddTicks(3320) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.AlterColumn<int>(
                name: "cloudId",
                table: "Notebooks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Notebooks",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "cloudId", "createdDate", "modifiedDate" },
                values: new object[] { null, new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1030), new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1031) });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1007), new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1009) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(766), new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(781) });
        }
    }
}
