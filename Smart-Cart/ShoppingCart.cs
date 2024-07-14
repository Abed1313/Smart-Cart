using System;
using System.Collections.Generic;

namespace Smart_Cart
{
    public class ShoppingCart
    {
        public static List<string> items = new List<string>();

        public static void AddOrRemoveItems()
        {
            Console.WriteLine("Welcome to Our Shopping Cart");
            Console.WriteLine("1-View Our Category");
            Console.WriteLine("2-Add Items");
            Console.WriteLine("3-View All Items");
            Console.WriteLine("4-Remove Items");
            Console.WriteLine("5-Total Price");
            Console.WriteLine("6-Exit");
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Choose Your Option");
                string shoppingOption = Console.ReadLine();
                switch (shoppingOption)
                {
                    case "1":
                        ViewOurCategory();
                        break;
                    case "2":
                        AddCategory();
                        break;
                    case "3":
                        ViewAllItems();
                        break;
                    case "4":
                        RemoveCategory();
                        break;
                    case "5":
                        int totalPrice = CalculateTotalPrice();
                        Console.WriteLine($"Total Price: {totalPrice}");
                        break;
                    case "6":
                        Console.WriteLine("Exiting the Shopping Cart");
                        return;
                    default:
                        Console.WriteLine("Invalid Option, Please Try Again");
                        break;
                }
            }
        }
        //////////////////////////ViewOurCategory////////////////////////
        public static void ViewOurCategory()
        {
            ProductCategory[] productCategories = (ProductCategory[])Enum.GetValues(typeof(ProductCategory));

            foreach (var item in productCategories)
            {
                Console.WriteLine($"Section: {item}");
            }
        }

        ///////////////////////// AddCategory ///////////////////////////
        public static void AddCategory()
        {
            Console.WriteLine("Please Choose your Store:\n1-Grocery Store\n2-Clothing Store\n3-Electronics Store");
            string chooseStore = Console.ReadLine();
            switch (chooseStore)
            {
                case "1":
                    //AddFoodItems();
                    //AddItems(typeof(Food));
                    GroceryStore.AddItems(typeof(Food));
                    break;
                case "2":
                    //AddClothingItems();
                    //AddItems(typeof(Clothing));
                    ClothingStore.AddItems(typeof(Clothing));
                    break;
                case "3":
                    //AddElectronicsItems();
                    AddItems(typeof(Electronics));
                    break;
                default:
                    Console.WriteLine("Invalid Store Choice"); 
                    return;
            }

            Console.WriteLine("Added successfully");
        }
        private static void AddItems(Type categoryType)
        {
            //Array itemsArray = Enum.GetValues(categoryType);
            bool tryAgain = true;
            while (tryAgain)
            {
                Console.WriteLine("Welcome to Electronics Store ");
                int[] itemsArray = (int[])Enum.GetValues(categoryType);
                Console.WriteLine("Please Choose your Items:");
                for (int i = 0; i < itemsArray.Length; i++)
                {
                    Console.WriteLine($"{i + 1}-{itemsArray.GetValue(i)}");
                }
                string chooseItem = Console.ReadLine();
                if (int.TryParse(chooseItem, out int itemNumber) && itemNumber > 0 && itemNumber <= itemsArray.Length)
                {
                    items.Add(itemsArray.GetValue(itemNumber - 1).ToString());
                    Console.WriteLine("Item added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid Input, please try again.");
                }
                Console.WriteLine("Press 0 to stop adding items, or any other key to continue:");
                string truefulse = Console.ReadLine();
                if (truefulse == "0")
                {
                    tryAgain = false;
                }
            }
        }

        //////////////////////////RemoveCategory/////////////////////////
        public static void RemoveCategory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No Items Added yet");
                return;
            }

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}-{items[i]}");
            }

            Console.WriteLine("Press the number of the item to remove from your cart");
            if (int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber > 0 && itemNumber <= items.Count) // Checks if the input is a valid integer within the range of the list's count
            {
                string itemToRemove = items[itemNumber - 1];
                items.RemoveAt(itemNumber - 1);                                 //Removes the item at the specified index
                Console.WriteLine($"Removed {itemToRemove} successfully");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        //////////////////////////ViewAllItems///////////////////////////
        public static void ViewAllItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No Items Added yet");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{items[i]}");
                }
            }
            Console.WriteLine("If You want to Remave Items Prss Y/N");
            string RemoveAfterViow = Console.ReadLine().ToUpper();
            if (RemoveAfterViow == "Y")
            {
                RemoveCategory();
            }
            else
            {
                return;
            }
        }
        //////////////////////////CalculateTotalPrice////////////////////
        public static int CalculateTotalPrice()
        {
            int total = 0;
            foreach (var item in items)
            {
                switch (item)
                {
                    case "Apple":
                        total += (int)Food.Apple;
                        break;
                    case "Bread":
                        total += (int)Food.Bread;
                        break;
                    case "Milk":
                        total += (int)Food.Milk;
                        break;
                    case "Cheese":
                        total += (int)Food.Cheese;
                        break;
                    case "Tshirt":
                        total += (int)Clothing.Tshirt;
                        break;
                    case "Jeans":
                        total += (int)Clothing.Jeans;
                        break;
                    case "Dress":
                        total += (int)Clothing.Dress;
                        break;
                    case "Sweater":
                        total += (int)Clothing.Sweater;
                        break;
                    case "Smartphone":
                        total += (int)Electronics.Smartphone;
                        break;
                    case "Laptop":
                        total += (int)Electronics.Laptop;
                        break;
                    case "Headphones":
                        total += (int)Electronics.Headphones;
                        break;
                    case "Tablet":
                        total += (int)Electronics.Tablet;
                        break;
                }
            }
            return total;
        }

        
    }
}
//NOTE * here 6 methode for Add and Remove Items , We can use it if we replesd *AddItems Method* for Add , and replesd 128-134 in *Remove Method* for Remove and make it like Add Method
//private static void AddFoodItems()
//{
//    Console.WriteLine("Please Choose your Items:\n1-Apple\n2-Bread\n3-Milk\n4-Cheese");
//    string chooseFood = Console.ReadLine();
//    switch (chooseFood)
//    {
//        case "1":
//            items.Add("Apple");
//            break;
//        case "2":
//            items.Add("Bread");
//            break;
//        case "3":
//            items.Add("Milk");
//            break;
//        case "4":
//            items.Add("Cheese");
//            break;
//        default:
//            Console.WriteLine("Invalid Input");
//            return;
//    }
//}

//private static void AddClothingItems()
//{
//    Console.WriteLine("Please Choose your Clothing:\n1-Tshirt\n2-Jeans\n3-Dress\n4-Sweater");
//    string chooseClothing = Console.ReadLine();
//    switch (chooseClothing)
//    {
//        case "1":
//            items.Add("Tshirt");
//            break;
//        case "2":
//            items.Add("Jeans");
//            break;
//        case "3":
//            items.Add("Dress");
//            break;
//        case "4":
//            items.Add("Sweater");
//            break;
//        default:
//            Console.WriteLine("Invalid Input");
//            return;
//    }
//}

//private static void AddElectronicsItems()
//{
//    Console.WriteLine("Please Choose your Electronics:\n1-Smartphone\n2-Laptop\n3-Headphones\n4-Tablet");
//    string chooseElectronics = Console.ReadLine();
//    switch (chooseElectronics)
//    {
//        case "1":
//            items.Add("Smartphone");
//            break;
//        case "2":
//            items.Add("Laptop");
//            break;
//        case "3":
//            items.Add("Headphones");
//            break;
//        case "4":
//            items.Add("Tablet");
//            break;
//        default:
//            Console.WriteLine("Invalid Input");
//            return;
//    }
////}
//private static void RemoveFoodItems()
//{
//    Console.WriteLine("Remove From your Items:\n1-Apple\n2-Bread\n3-Milk\n4-Cheese");
//    string chooseFood = Console.ReadLine();
//    switch (chooseFood)
//    {
//        case "1":
//            items.Remove("Apple");
//            break;
//        case "2":
//            items.Remove("Bread");
//            break;
//        case "3":
//            items.Remove("Milk");
//            break;
//        case "4":
//            items.Remove("Cheese");
//            break;
//        default:
//            Console.WriteLine("Invalid Input");
//            return;
//    }
//}
//private static void RemoveClothingItems()
//{
//    Console.WriteLine("Remove From your Clothing:\n1-Tshirt\n2-Jeans\n3-Dress\n4-Sweater");
//    string chooseClothing = Console.ReadLine();
//    switch (chooseClothing)
//    {
//        case "1":
//            items.Remove("Tshirt");
//            break;
//        case "2":
//            items.Remove("Jeans");
//            break;
//        case "3":
//            items.Remove("Dress");
//            break;
//        case "4":
//            items.Remove("Sweater");
//            break;
//        default:
//            Console.WriteLine("Invalid Input");
//            return;
//    }
//}
//private static void RemoveElectronicsItems()
//{
//    Console.WriteLine("Remove From your Electronics:\n1-Smartphone\n2-Laptop\n3-Headphones\n4-Tablet");
//    string chooseElectronics = Console.ReadLine();
//    switch (chooseElectronics)
//    {
//        case "1":
//            items.Remove("Smartphone");
//            break;
//        case "2":
//            items.Remove("Laptop");
//            break;
//        case "3":
//            items.Remove("Headphones");
//            break;
//        case "4":
//            items.Remove("Tablet");
//            break;
//        default:
//            Console.WriteLine("Invalid Input");
//            return;
//    }
//}