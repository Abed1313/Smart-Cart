namespace Smart_Cart
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShoppingCart.AddOrRemoveItems();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
