using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateJoined", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Username" },
                values: new object[] { 2, new DateTime(2023, 4, 4, 18, 15, 15, 115, DateTimeKind.Local).AddTicks(1924), "Admin", true, "User", new byte[] { 181, 233, 117, 107, 188, 87, 224, 174, 111, 90, 241, 100, 82, 154, 24, 28, 188, 116, 24, 215, 56, 20, 125, 186, 187, 229, 166, 75, 181, 76, 82, 157, 179, 70, 144, 86, 47, 241, 17, 21, 38, 74, 28, 136, 126, 151, 15, 184, 128, 166, 58, 52, 41, 177, 79, 230, 238, 23, 160, 224, 250, 157, 94, 214 }, new byte[] { 111, 194, 188, 9, 206, 129, 245, 244, 221, 62, 247, 5, 35, 255, 58, 72, 86, 249, 39, 159, 162, 75, 242, 40, 4, 17, 157, 223, 120, 179, 111, 175, 143, 134, 155, 141, 248, 84, 1, 252, 104, 219, 203, 194, 8, 162, 253, 193, 148, 228, 33, 48, 55, 60, 167, 49, 178, 166, 2, 122, 138, 208, 170, 130, 39, 26, 76, 72, 172, 111, 38, 20, 175, 47, 38, 186, 154, 187, 54, 109, 18, 159, 100, 129, 31, 103, 204, 81, 11, 201, 223, 250, 115, 63, 54, 97, 114, 220, 124, 141, 227, 218, 253, 119, 58, 83, 163, 231, 234, 222, 80, 2, 242, 30, 179, 217, 101, 170, 156, 226, 5, 66, 78, 246, 118, 153, 37, 19 }, 1234567890, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateJoined", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Username" },
                values: new object[] { 1, new DateTime(2023, 4, 4, 18, 13, 43, 960, DateTimeKind.Local).AddTicks(3066), "Admin", true, "User", new byte[] { 145, 102, 236, 36, 128, 72, 13, 250, 50, 28, 83, 155, 115, 52, 82, 244, 245, 98, 253, 30, 198, 40, 182, 47, 84, 159, 122, 0, 219, 134, 58, 142, 99, 145, 8, 101, 249, 220, 46, 155, 68, 128, 231, 132, 216, 176, 100, 162, 138, 17, 2, 113, 236, 214, 203, 46, 186, 115, 35, 176, 150, 36, 203, 113 }, new byte[] { 6, 125, 67, 77, 84, 111, 38, 133, 7, 222, 0, 25, 55, 21, 194, 30, 202, 82, 61, 186, 116, 186, 207, 217, 33, 158, 133, 55, 83, 17, 48, 116, 96, 231, 248, 102, 94, 187, 216, 43, 57, 248, 3, 152, 8, 61, 142, 157, 74, 60, 77, 160, 110, 247, 33, 211, 252, 76, 147, 7, 6, 146, 202, 198, 40, 53, 62, 226, 8, 22, 46, 49, 113, 250, 42, 223, 228, 133, 218, 32, 134, 18, 119, 57, 75, 211, 146, 68, 84, 11, 173, 148, 199, 255, 126, 10, 127, 117, 137, 58, 45, 32, 192, 132, 140, 15, 70, 82, 11, 21, 255, 178, 178, 30, 63, 150, 156, 103, 23, 92, 172, 189, 109, 77, 135, 169, 170, 58 }, 1234567890, "admin" });
        }
    }
}
