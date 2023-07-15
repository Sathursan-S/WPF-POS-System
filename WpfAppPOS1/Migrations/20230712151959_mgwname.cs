using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mgwname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InvoiceID",
                table: "Invoices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceID",
                table: "CartItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "CartItemID",
                table: "CartItems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "CartItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 60, 116, 42, 54, 193, 115, 30, 9, 128, 136, 0, 14, 203, 101, 210, 71, 240, 111, 185, 43, 11, 173, 87, 164, 171, 238, 28, 60, 192, 154, 214, 34, 250, 130, 189, 72, 100, 219, 131, 95, 45, 171, 184, 231, 52, 230, 14, 126, 125, 58, 68, 229, 76, 77, 51, 187, 242, 155, 173, 84, 213, 217, 94, 27 }, new byte[] { 203, 228, 183, 116, 228, 133, 199, 12, 118, 143, 231, 237, 119, 213, 149, 77, 72, 57, 73, 146, 219, 45, 124, 95, 144, 127, 249, 214, 199, 32, 140, 76, 199, 27, 200, 181, 172, 8, 46, 157, 99, 71, 119, 44, 148, 180, 166, 52, 27, 141, 22, 196, 117, 97, 110, 214, 184, 41, 219, 227, 142, 72, 154, 34, 143, 199, 56, 231, 58, 47, 18, 220, 153, 145, 123, 129, 156, 182, 136, 155, 8, 24, 137, 121, 91, 180, 83, 63, 41, 170, 247, 143, 20, 193, 94, 225, 38, 38, 210, 99, 89, 168, 163, 24, 152, 214, 123, 224, 52, 102, 127, 39, 114, 58, 23, 72, 105, 212, 210, 171, 62, 23, 185, 205, 45, 175, 140, 8 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "Invoices",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceID",
                table: "CartItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "CartItemID",
                table: "CartItems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 181, 136, 102, 23, 109, 44, 204, 176, 252, 133, 138, 178, 70, 160, 248, 219, 42, 120, 60, 200, 86, 91, 120, 238, 12, 216, 161, 10, 135, 165, 60, 103, 183, 234, 9, 26, 184, 152, 119, 194, 254, 219, 176, 183, 227, 83, 102, 189, 162, 250, 39, 144, 113, 252, 220, 7, 66, 99, 187, 212, 191, 4, 122, 164 }, new byte[] { 129, 227, 11, 112, 57, 80, 187, 167, 36, 11, 96, 26, 157, 31, 87, 239, 233, 242, 23, 202, 69, 72, 26, 224, 16, 19, 208, 130, 164, 13, 210, 82, 15, 223, 156, 191, 84, 209, 39, 190, 161, 21, 35, 199, 173, 208, 66, 224, 102, 27, 154, 56, 24, 106, 255, 115, 245, 239, 45, 18, 125, 97, 171, 240, 222, 43, 69, 183, 51, 237, 199, 35, 240, 226, 138, 17, 249, 165, 89, 202, 67, 100, 69, 96, 151, 179, 23, 242, 117, 182, 8, 140, 5, 131, 243, 140, 125, 136, 172, 132, 18, 21, 27, 85, 35, 186, 213, 190, 113, 92, 214, 123, 46, 13, 233, 236, 230, 38, 57, 48, 140, 30, 64, 170, 36, 193, 11, 25 } });
        }
    }
}
