using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class dataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notebooks",
                columns: new[] { "id", "checkedCount", "cloudId", "createdDate", "imageCount", "modifiedDate", "name", "notebookType", "shareStatus", "textCount", "uncheckedCount" },
                values: new object[] { 1, null, null, new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1030), null, new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1031), "Sample", null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(766), new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(781) });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "id", "Discriminator", "createdDate", "isChecked", "modifiedDate", "noteType", "notebookId", "stickerNote", "stickerType", "textNote" },
                values: new object[] { 1, "Note", new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1007), null, new DateTime(2023, 4, 10, 11, 5, 11, 662, DateTimeKind.Local).AddTicks(1009), null, 1, null, null, "Sample" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notebooks",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "createdDate", "modifiedDate" },
                values: new object[] { new DateTime(2023, 4, 10, 10, 58, 22, 391, DateTimeKind.Local).AddTicks(7927), new DateTime(2023, 4, 10, 10, 58, 22, 391, DateTimeKind.Local).AddTicks(7942) });
        }
    }
}
