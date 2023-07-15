using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mg20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Username" },
                values: new object[] { 1002, "Default", true, "Admin", new byte[] { 249, 17, 126, 59, 205, 199, 125, 159, 240, 185, 218, 84, 44, 167, 23, 54, 228, 159, 19, 110, 130, 139, 103, 211, 131, 42, 184, 84, 141, 171, 79, 99, 75, 137, 35, 202, 50, 196, 165, 110, 52, 88, 252, 205, 236, 143, 59, 254, 4, 73, 23, 71, 155, 64, 148, 53, 187, 247, 47, 185, 97, 140, 196, 102 }, new byte[] { 180, 2, 96, 168, 116, 188, 31, 169, 52, 75, 40, 241, 55, 113, 205, 219, 184, 238, 84, 209, 160, 244, 251, 52, 64, 252, 68, 134, 14, 251, 179, 231, 216, 237, 233, 10, 245, 89, 47, 148, 9, 125, 109, 173, 62, 251, 235, 177, 246, 176, 77, 125, 187, 47, 187, 129, 157, 209, 29, 240, 145, 121, 248, 235, 41, 0, 223, 78, 131, 114, 112, 56, 222, 212, 237, 131, 19, 21, 155, 39, 113, 85, 184, 170, 69, 111, 39, 64, 25, 236, 91, 124, 113, 234, 85, 12, 105, 73, 185, 66, 137, 241, 126, 83, 124, 217, 106, 105, 209, 83, 134, 192, 186, 38, 34, 159, 2, 94, 177, 159, 87, 152, 182, 129, 63, 89, 214, 210 }, 123456789, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductID",
                table: "Stocks",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductID",
                table: "Stocks",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductID",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductID",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Username" },
                values: new object[] { 2, "Default", true, "Admin", new byte[] { 103, 27, 10, 14, 75, 114, 35, 12, 110, 152, 142, 132, 96, 56, 45, 175, 88, 58, 32, 213, 75, 163, 87, 234, 239, 53, 236, 70, 16, 156, 245, 209, 60, 17, 41, 130, 65, 107, 65, 117, 103, 7, 36, 167, 48, 110, 71, 109, 14, 112, 237, 196, 212, 254, 139, 175, 85, 129, 228, 227, 84, 113, 183, 214 }, new byte[] { 27, 207, 159, 128, 252, 232, 214, 79, 109, 100, 230, 170, 149, 243, 219, 65, 71, 158, 104, 210, 209, 218, 217, 174, 63, 94, 160, 46, 9, 66, 42, 106, 1, 136, 132, 127, 59, 44, 61, 247, 108, 33, 48, 241, 45, 28, 208, 77, 18, 69, 35, 43, 114, 233, 110, 115, 86, 60, 207, 0, 213, 45, 8, 25, 50, 179, 126, 192, 47, 8, 73, 154, 175, 157, 104, 94, 161, 37, 208, 254, 83, 158, 77, 124, 162, 13, 73, 255, 21, 61, 29, 153, 104, 13, 215, 218, 2, 130, 192, 168, 64, 135, 255, 194, 177, 32, 124, 111, 228, 15, 15, 180, 5, 123, 198, 239, 238, 187, 69, 187, 142, 36, 138, 208, 20, 76, 18, 179 }, 123456789, "admin" });
        }
    }
}
