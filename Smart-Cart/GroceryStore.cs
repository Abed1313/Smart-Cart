using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Cart
{
    public class GroceryStore
    {
        public static void AddItems(Type Food)
        {
           bool tryAgain = true;
            while (tryAgain)
            {
                Console.WriteLine("Welcome to Grocery Store ");
                int[] itemsArray = (int[])Enum.GetValues(Food);
                Console.WriteLine("Please Choose your Items:");
                for (int i = 0; i < itemsArray.Length; i++)
                {
                    Console.WriteLine($"{i + 1}-{itemsArray.GetValue(i)}");
                }
                string chooseItem = Console.ReadLine();
                if (int.TryParse(chooseItem, out int itemNumber) && itemNumber > 0 && itemNumber <= itemsArray.Length)
                {
                    ShoppingCart.items.Add(itemsArray.GetValue(itemNumber - 1).ToString());
                    Console.WriteLine("Item added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again.");
                }
                Console.WriteLine("Press 0 to stop adding items, or any other key to continue:");
                string truefulse = Console.ReadLine();
                if(truefulse == "0" )
                {
                    tryAgain = false;
                }
            } 
            
        }
    }
}
