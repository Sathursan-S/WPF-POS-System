using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPOS1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        //public int QuantityInStock { get; set; }
        public string Description { get; set; }

        public Product()
        {
            ProductID = GenerateProductId();
        }

        // create a static property to generate a unic product id 001
        private static int _ProductID = 1001;
        public static int GenerateProductId()
        {
            _ProductID++;
            return _ProductID;
        }
    }
}
