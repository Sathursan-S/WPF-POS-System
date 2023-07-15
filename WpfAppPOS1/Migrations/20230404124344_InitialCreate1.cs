using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateJoined", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Username" },
                values: new object[] { 1, new DateTime(2023, 4, 4, 18, 13, 43, 960, DateTimeKind.Local).AddTicks(3066), "Admin", true, "User", new byte[] { 145, 102, 236, 36, 128, 72, 13, 250, 50, 28, 83, 155, 115, 52, 82, 244, 245, 98, 253, 30, 198, 40, 182, 47, 84, 159, 122, 0, 219, 134, 58, 142, 99, 145, 8, 101, 249, 220, 46, 155, 68, 128, 231, 132, 216, 176, 100, 162, 138, 17, 2, 113, 236, 214, 203, 46, 186, 115, 35, 176, 150, 36, 203, 113 }, new byte[] { 6, 125, 67, 77, 84, 111, 38, 133, 7, 222, 0, 25, 55, 21, 194, 30, 202, 82, 61, 186, 116, 186, 207, 217, 33, 158, 133, 55, 83, 17, 48, 116, 96, 231, 248, 102, 94, 187, 216, 43, 57, 248, 3, 152, 8, 61, 142, 157, 74, 60, 77, 160, 110, 247, 33, 211, 252, 76, 147, 7, 6, 146, 202, 198, 40, 53, 62, 226, 8, 22, 46, 49, 113, 250, 42, 223, 228, 133, 218, 32, 134, 18, 119, 57, 75, 211, 146, 68, 84, 11, 173, 148, 199, 255, 126, 10, 127, 117, 137, 58, 45, 32, 192, 132, 140, 15, 70, 82, 11, 21, 255, 178, 178, 30, 63, 150, 156, 103, 23, 92, 172, 189, 109, 77, 135, 169, 170, 58 }, 1234567890, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
