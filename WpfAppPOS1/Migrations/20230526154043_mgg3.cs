using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mgg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new byte[] { 38, 190, 23, 240, 184, 53, 3, 125, 79, 59, 50, 94, 188, 15, 233, 126, 132, 206, 252, 162, 244, 62, 199, 183, 163, 68, 113, 174, 106, 43, 75, 237, 151, 38, 244, 187, 174, 46, 169, 156, 100, 212, 242, 61, 45, 242, 159, 208, 182, 37, 43, 156, 104, 145, 93, 170, 109, 18, 82, 17, 3, 146, 85, 134 }, new byte[] { 106, 107, 102, 109, 188, 88, 37, 149, 81, 253, 89, 45, 135, 91, 100, 80, 8, 84, 102, 177, 64, 187, 37, 35, 18, 2, 84, 143, 239, 112, 45, 134, 188, 76, 177, 191, 228, 101, 146, 57, 181, 166, 166, 97, 193, 76, 67, 180, 9, 137, 45, 2, 172, 86, 28, 209, 23, 179, 37, 224, 20, 187, 229, 144, 254, 136, 140, 45, 239, 138, 141, 223, 74, 164, 105, 85, 81, 58, 0, 246, 5, 177, 210, 166, 224, 232, 10, 75, 220, 9, 64, 124, 128, 168, 49, 197, 161, 215, 195, 199, 68, 129, 16, 22, 89, 208, 239, 96, 66, 59, 66, 218, 233, 204, 200, 38, 245, 203, 201, 83, 140, 167, 226, 107, 148, 186, 152, 109 } });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new byte[] { 91, 83, 240, 33, 84, 155, 164, 198, 166, 55, 61, 44, 52, 208, 125, 175, 34, 225, 214, 90, 87, 228, 139, 124, 202, 179, 226, 64, 29, 188, 166, 128, 18, 34, 43, 66, 121, 67, 75, 27, 213, 39, 45, 153, 21, 86, 202, 189, 208, 241, 1, 82, 37, 181, 106, 159, 19, 132, 17, 151, 157, 45, 64, 171 }, new byte[] { 231, 49, 211, 69, 159, 255, 159, 27, 228, 63, 2, 50, 243, 25, 43, 173, 82, 197, 163, 35, 57, 219, 26, 253, 27, 19, 105, 126, 253, 82, 104, 170, 216, 71, 13, 86, 47, 213, 18, 111, 195, 51, 122, 75, 71, 170, 170, 204, 142, 152, 246, 69, 56, 127, 98, 111, 209, 43, 107, 80, 27, 68, 23, 3, 86, 221, 7, 143, 114, 181, 250, 201, 48, 141, 107, 154, 47, 184, 142, 127, 69, 227, 81, 160, 215, 63, 120, 100, 144, 104, 156, 226, 215, 74, 127, 129, 79, 228, 105, 116, 175, 220, 144, 141, 160, 167, 87, 63, 27, 163, 116, 225, 65, 240, 213, 231, 49, 7, 239, 21, 30, 111, 71, 54, 79, 28, 132, 142 } });

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
    }
}
