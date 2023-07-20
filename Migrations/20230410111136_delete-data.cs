using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class deletedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "id", "Discriminator", "createdDate", "isChecked", "modifiedDate", "noteType", "notebookId", "stickerNote", "stickerType", "textNote" },
                values: new object[] { 1, "Note", new DateTime(2023, 4, 10, 14, 7, 31, 383, DateTimeKind.Local).AddTicks(3299), null, new DateTime(2023, 4, 10, 14, 7, 31, 383, DateTimeKind.Local).AddTicks(3301), null, 1, null, null, "Sample" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "createdDate", "displayName", "email", "emailVerified", "isLoggedin", "modifiedDate", "photoURL", "uid" },
                values: new object[] { 1, new DateTime(2023, 4, 10, 14, 7, 31, 383, DateTimeKind.Local).AddTicks(3122), "merve", "merve@merve.com", null, null, new DateTime(2023, 4, 10, 14, 7, 31, 383, DateTimeKind.Local).AddTicks(3137), null, "" });
        }
    }
}
