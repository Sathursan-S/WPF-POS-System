using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPOS1.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        //public Product Product { get; set; }
        public virtual Product Product { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double CostPrice { get; set; }
        public double SellingPrice { get; set; }
        public DateTime LastUpdated { get; set; }

        public Stock()
        {
            StockId = GenerateStockId();
        }
        
        // create a static property to generate a unic product id 001
        private static int _StockID = 2001;
        public static int GenerateStockId()
        {
            _StockID++;
            return _StockID;
        }

    }
}