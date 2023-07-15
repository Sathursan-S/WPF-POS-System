using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mg200 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "CartItem",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "CartItem",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Discount",
                table: "CartItem",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 140, 148, 195, 76, 151, 155, 10, 130, 145, 110, 20, 26, 9, 48, 247, 171, 15, 63, 108, 177, 245, 185, 136, 119, 206, 74, 226, 180, 73, 232, 192, 155, 76, 31, 228, 251, 37, 255, 42, 100, 168, 158, 56, 142, 152, 100, 9, 25, 62, 102, 58, 53, 224, 49, 5, 82, 176, 189, 85, 244, 30, 182, 197, 104 }, new byte[] { 223, 15, 33, 113, 163, 39, 117, 4, 144, 9, 235, 45, 151, 41, 18, 243, 186, 124, 88, 132, 92, 240, 245, 69, 83, 72, 160, 128, 130, 31, 74, 189, 54, 21, 166, 111, 116, 107, 199, 187, 15, 73, 106, 253, 212, 37, 200, 96, 189, 70, 174, 104, 141, 116, 138, 13, 214, 38, 199, 37, 76, 218, 133, 160, 81, 166, 240, 244, 180, 48, 98, 206, 31, 33, 180, 67, 102, 190, 17, 198, 150, 112, 66, 119, 157, 185, 20, 93, 182, 7, 26, 16, 114, 46, 251, 133, 127, 235, 17, 79, 245, 176, 89, 140, 119, 212, 157, 24, 161, 202, 50, 27, 98, 42, 136, 71, 45, 186, 158, 1, 62, 191, 34, 193, 32, 146, 218, 89 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "CartItem",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "CartItem",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "CartItem",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 60, 32, 60, 237, 252, 57, 206, 252, 52, 166, 107, 74, 247, 61, 125, 216, 49, 219, 18, 194, 144, 62, 220, 215, 27, 37, 213, 88, 152, 49, 243, 92, 55, 238, 179, 251, 49, 115, 156, 93, 147, 146, 131, 2, 114, 113, 240, 212, 61, 229, 226, 96, 100, 86, 193, 2, 219, 233, 61, 235, 200, 143, 197, 110 }, new byte[] { 5, 48, 253, 200, 50, 177, 133, 56, 150, 20, 90, 107, 205, 254, 191, 37, 186, 40, 183, 213, 182, 157, 136, 111, 231, 118, 160, 241, 215, 138, 82, 154, 137, 42, 215, 230, 53, 221, 74, 229, 66, 224, 233, 241, 150, 20, 167, 44, 109, 253, 142, 246, 133, 127, 226, 200, 144, 135, 106, 246, 155, 29, 44, 160, 123, 169, 190, 224, 170, 64, 55, 106, 173, 29, 31, 76, 213, 122, 163, 187, 193, 164, 139, 166, 192, 241, 7, 41, 110, 213, 57, 221, 151, 6, 21, 208, 22, 179, 70, 94, 92, 184, 245, 196, 146, 78, 118, 47, 63, 230, 245, 238, 247, 233, 198, 113, 59, 59, 84, 83, 20, 137, 49, 177, 190, 237, 237, 50 } });
        }
    }
}
