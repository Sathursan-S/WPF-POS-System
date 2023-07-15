using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WpfAppPOS1.Models;


namespace WpfAppPOS1.Models
{
    public class CartItem
    {
        public string CartItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string InvoiceID { get; set; }
        public virtual Product Product { get; set; }
        public Invoice Invoice { get; set; } = null!;
        //public virtual Invoice Invoice { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double TotalPrice { get; set; }
        private static int count = 0;

        //default constructor
        public CartItem()
        {
            count++;
            CartItemID = GenerateCartItemID();
        }
        //overload constuctor
        public CartItem(Product product, int quantity, double discount, Invoice inv)
        {
            count++;
            CartItemID = GenerateCartItemID();
            ProductID = product.ProductID;
            ProductName= product.Name;
            InvoiceID = inv.InvoiceID;
            Quantity = quantity;
            Discount = discount;
            UnitPrice = (double)product.UnitPrice;
            TotalPrice = (UnitPrice * Quantity)-Discount;
        }

        private string GenerateCartItemID()
        {
            // Convert DateTime.Now to a unique numeric value
            string uniqueValue = DateTime.Now.ToString("yyMMddHHmmss");
            return (uniqueValue);
        }
    }
}
