using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mg201 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Invoices_InvoiceID",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItems",
                newName: "IX_CartItems_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_InvoiceID",
                table: "CartItems",
                newName: "IX_CartItems_InvoiceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems",
                column: "CartItemID");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 28, 218, 112, 251, 207, 233, 53, 167, 255, 52, 138, 109, 194, 8, 212, 58, 142, 84, 87, 240, 88, 50, 48, 139, 175, 7, 30, 251, 138, 96, 73, 92, 111, 67, 222, 84, 98, 206, 112, 45, 144, 82, 221, 235, 31, 197, 144, 199, 49, 1, 45, 224, 214, 255, 45, 232, 209, 135, 168, 54, 152, 68, 65, 175 }, new byte[] { 142, 163, 11, 99, 63, 237, 242, 241, 230, 90, 233, 128, 205, 182, 74, 203, 223, 8, 163, 140, 180, 198, 142, 118, 160, 170, 177, 51, 217, 41, 4, 249, 234, 239, 79, 159, 66, 91, 83, 132, 169, 244, 190, 37, 62, 64, 109, 17, 47, 157, 18, 4, 252, 78, 126, 158, 123, 216, 27, 133, 237, 82, 201, 63, 211, 157, 179, 180, 244, 106, 153, 171, 65, 190, 216, 215, 51, 85, 66, 219, 116, 1, 201, 83, 137, 105, 137, 192, 182, 23, 135, 207, 186, 4, 62, 169, 7, 117, 179, 117, 65, 89, 195, 121, 139, 97, 83, 75, 88, 9, 152, 185, 235, 91, 68, 142, 241, 218, 168, 127, 148, 179, 96, 237, 140, 56, 137, 153 } });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Invoices_InvoiceID",
                table: "CartItems",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Invoices_InvoiceID",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_ProductID",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItems",
                table: "CartItems");

            migrationBuilder.RenameTable(
                name: "CartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_ProductID",
                table: "CartItem",
                newName: "IX_CartItem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_CartItems_InvoiceID",
                table: "CartItem",
                newName: "IX_CartItem_InvoiceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "CartItemID");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 140, 148, 195, 76, 151, 155, 10, 130, 145, 110, 20, 26, 9, 48, 247, 171, 15, 63, 108, 177, 245, 185, 136, 119, 206, 74, 226, 180, 73, 232, 192, 155, 76, 31, 228, 251, 37, 255, 42, 100, 168, 158, 56, 142, 152, 100, 9, 25, 62, 102, 58, 53, 224, 49, 5, 82, 176, 189, 85, 244, 30, 182, 197, 104 }, new byte[] { 223, 15, 33, 113, 163, 39, 117, 4, 144, 9, 235, 45, 151, 41, 18, 243, 186, 124, 88, 132, 92, 240, 245, 69, 83, 72, 160, 128, 130, 31, 74, 189, 54, 21, 166, 111, 116, 107, 199, 187, 15, 73, 106, 253, 212, 37, 200, 96, 189, 70, 174, 104, 141, 116, 138, 13, 214, 38, 199, 37, 76, 218, 133, 160, 81, 166, 240, 244, 180, 48, 98, 206, 31, 33, 180, 67, 102, 190, 17, 198, 150, 112, 66, 119, 157, 185, 20, 93, 182, 7, 26, 16, 114, 46, 251, 133, 127, 235, 17, 79, 245, 176, 89, 140, 119, 212, 157, 24, 161, 202, 50, 27, 98, 42, 136, 71, 45, 186, 158, 1, 62, 191, 34, 193, 32, 146, 218, 89 } });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Invoices_InvoiceID",
                table: "CartItem",
                column: "InvoiceID",
                principalTable: "Invoices",
                principalColumn: "InvoiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductID",
                table: "CartItem",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
