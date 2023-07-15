using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mgg4 : Migration
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
                values: new object[] { new byte[] { 255, 52, 161, 129, 199, 63, 205, 143, 182, 12, 74, 210, 142, 44, 139, 34, 70, 156, 119, 209, 130, 232, 31, 159, 105, 109, 232, 58, 17, 20, 132, 18, 83, 153, 133, 200, 40, 94, 194, 193, 69, 97, 124, 11, 122, 6, 172, 85, 80, 166, 13, 87, 68, 42, 178, 17, 36, 36, 150, 136, 157, 124, 113, 97 }, new byte[] { 206, 81, 138, 185, 217, 190, 171, 185, 119, 115, 235, 203, 166, 254, 158, 80, 189, 211, 251, 184, 44, 249, 126, 125, 24, 168, 34, 215, 112, 208, 176, 37, 4, 225, 135, 68, 248, 202, 245, 78, 72, 72, 112, 202, 23, 126, 255, 71, 202, 212, 233, 193, 36, 165, 133, 94, 252, 109, 199, 12, 238, 44, 119, 29, 45, 150, 161, 217, 177, 22, 35, 18, 138, 19, 0, 58, 158, 8, 91, 126, 92, 129, 109, 72, 64, 240, 209, 147, 163, 137, 236, 214, 66, 214, 104, 252, 182, 197, 212, 21, 175, 126, 101, 140, 215, 74, 13, 224, 40, 141, 128, 177, 252, 132, 178, 236, 69, 94, 138, 146, 47, 179, 73, 111, 205, 117, 56, 72 } });

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
    }
}
