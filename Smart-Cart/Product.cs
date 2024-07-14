using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart
{
    public enum ProductCategory
    {
        Food ,
        Clothing ,
        Electronics ,
    }
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }

    }
}
