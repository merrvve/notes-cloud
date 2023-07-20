using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nc2.Migrations
{
    /// <inheritdoc />
    public partial class useradd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "createdDate", "displayName", "email", "emailVerified", "isLoggedin", "modifiedDate", "photoURL", "uid" },
                values: new object[] { 1, new DateTime(2023, 4, 6, 14, 2, 24, 584, DateTimeKind.Local).AddTicks(1489), "merve", "merve@merve.com", null, null, new DateTime(2023, 4, 6, 14, 2, 24, 584, DateTimeKind.Local).AddTicks(1502), null, "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
