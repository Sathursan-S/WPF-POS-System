using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfAppPOS1.Models;


namespace WpfAppPOS1.Models
{
    public class Invoice
    {
        public string InvoiceID { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<CartItem> CartItems{ get; set; } = new List<CartItem>();
        public double Total { get; set; }
        public double AmountTendered { get; set; }
        public double Change { get; set; }

        //private static int _idCounter = 1;
        //private static readonly object _idLock = new object();

        //default constructor
        public Invoice()
        {
            
            InvoiceID = GenerateInvoiceID();
            DateTime = DateTime.Now;
        }

        public void Call()
        {
            Total = CartItems.Sum(x => x.TotalPrice);
            Change = AmountTendered - Total;
        }

        public Invoice(List<CartItem> cartItems) : this()
        {
            DateTime = DateTime.Now;
            CartItems = cartItems;
            Total = CartItems.Sum(x => x.TotalPrice);
            AmountTendered = 0;
            Change = 0;
        }

        public Invoice(List<CartItem> cartItems, double amountTendered) : this(cartItems)
        {
            AmountTendered = amountTendered;
            
        }

        public Invoice(List<CartItem> cartItems, double amountTendered, double change) : this(cartItems, amountTendered)
        {
            Change = change;
        }

        //genarate new id
        private string GenerateInvoiceID()
        {
            // Convert DateTime.Now to a unique numeric value
            string uniqueValue = DateTime.Now.ToString("yyMMddHHmmss");
            return uniqueValue;
        }
    }
}