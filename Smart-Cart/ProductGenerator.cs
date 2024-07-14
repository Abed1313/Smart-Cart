using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart
{
    public enum Food
    {
        Apple = 3,
        Bread = 4,
        Milk = 5,
        Cheese = 2
    }
    public enum Clothing
    {
        Tshirt = 22,
        Jeans = 20,
        Dress = 18,
        Sweater = 13
    }
    public enum Electronics
    {
        Smartphone = 33,
        Laptop = 29,
        Headphones = 22,
        Tablet = 10
    }
    public class ProductGenerator
    {
        public string Name { get; set; }
        public int Prise { get; set; }

    }
}
