using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "Invoices",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Change",
                table: "Invoices",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "AmountTendered",
                table: "Invoices",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 52, 19, 154, 19, 120, 34, 228, 126, 5, 44, 43, 178, 245, 59, 125, 146, 26, 49, 30, 43, 192, 90, 142, 113, 171, 137, 149, 55, 103, 67, 35, 123, 33, 227, 230, 97, 237, 204, 184, 14, 86, 26, 13, 156, 214, 151, 162, 44, 220, 161, 94, 226, 182, 129, 240, 208, 234, 115, 226, 119, 254, 172, 19, 126 }, new byte[] { 89, 156, 134, 239, 66, 230, 24, 88, 90, 118, 118, 238, 187, 151, 191, 128, 211, 85, 252, 149, 1, 136, 53, 59, 164, 207, 205, 248, 230, 105, 22, 14, 133, 78, 16, 63, 13, 82, 57, 167, 18, 70, 152, 170, 180, 68, 121, 20, 25, 222, 242, 114, 78, 242, 54, 129, 236, 219, 39, 184, 217, 247, 112, 132, 198, 81, 168, 150, 158, 244, 37, 215, 80, 18, 129, 24, 234, 22, 207, 6, 68, 68, 116, 172, 40, 205, 204, 164, 159, 190, 129, 158, 135, 102, 67, 11, 125, 84, 169, 143, 133, 95, 228, 196, 246, 70, 48, 166, 216, 175, 197, 138, 207, 55, 192, 224, 103, 236, 74, 187, 26, 22, 230, 55, 85, 68, 135, 220 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Change",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountTendered",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 28, 218, 112, 251, 207, 233, 53, 167, 255, 52, 138, 109, 194, 8, 212, 58, 142, 84, 87, 240, 88, 50, 48, 139, 175, 7, 30, 251, 138, 96, 73, 92, 111, 67, 222, 84, 98, 206, 112, 45, 144, 82, 221, 235, 31, 197, 144, 199, 49, 1, 45, 224, 214, 255, 45, 232, 209, 135, 168, 54, 152, 68, 65, 175 }, new byte[] { 142, 163, 11, 99, 63, 237, 242, 241, 230, 90, 233, 128, 205, 182, 74, 203, 223, 8, 163, 140, 180, 198, 142, 118, 160, 170, 177, 51, 217, 41, 4, 249, 234, 239, 79, 159, 66, 91, 83, 132, 169, 244, 190, 37, 62, 64, 109, 17, 47, 157, 18, 4, 252, 78, 126, 158, 123, 216, 27, 133, 237, 82, 201, 63, 211, 157, 179, 180, 244, 106, 153, 171, 65, 190, 216, 215, 51, 85, 66, 219, 116, 1, 201, 83, 137, 105, 137, 192, 182, 23, 135, 207, 186, 4, 62, 169, 7, 117, 179, 117, 65, 89, 195, 121, 139, 97, 83, 75, 88, 9, 152, 185, 235, 91, 68, 142, 241, 218, 168, 127, 148, 179, 96, 237, 140, 56, 137, 153 } });
        }
    }
}
