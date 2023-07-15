using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppPOS1.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    AmountTendered = table.Column<decimal>(type: "TEXT", nullable: false),
                    Change = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    QuantityInStock = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CostPrice = table.Column<double>(type: "REAL", nullable: false),
                    SellingPrice = table.Column<double>(type: "REAL", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false),
                    InvoiceID = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Discount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemID);
                    table.ForeignKey(
                        name: "FK_CartItem_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsAdmin", "LastName", "PasswordHash", "PasswordSalt", "Phone", "Username" },
                values: new object[] { 2, "Default", true, "Admin", new byte[] { 169, 33, 67, 51, 211, 190, 22, 69, 222, 250, 177, 212, 210, 33, 219, 136, 26, 190, 12, 122, 22, 225, 78, 229, 44, 139, 94, 97, 234, 167, 42, 221, 108, 64, 26, 110, 229, 168, 99, 52, 194, 214, 102, 168, 238, 197, 46, 70, 239, 51, 45, 116, 209, 175, 177, 149, 22, 186, 200, 120, 3, 246, 207, 138 }, new byte[] { 30, 74, 97, 140, 43, 166, 166, 221, 149, 94, 254, 218, 196, 34, 244, 192, 85, 52, 228, 118, 100, 56, 83, 46, 243, 41, 142, 93, 26, 3, 206, 199, 12, 200, 71, 3, 54, 111, 203, 95, 99, 108, 144, 227, 249, 167, 69, 7, 65, 171, 248, 25, 56, 75, 31, 108, 11, 194, 2, 168, 190, 168, 151, 120, 238, 209, 147, 209, 235, 90, 82, 142, 159, 219, 161, 13, 146, 173, 168, 87, 168, 10, 117, 47, 69, 134, 19, 102, 90, 174, 85, 78, 192, 74, 212, 147, 190, 199, 11, 98, 219, 219, 73, 94, 172, 124, 241, 132, 224, 232, 90, 17, 157, 117, 101, 42, 135, 4, 129, 102, 50, 28, 169, 100, 95, 246, 215, 196 }, 123456789, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_InvoiceID",
                table: "CartItem",
                column: "InvoiceID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
