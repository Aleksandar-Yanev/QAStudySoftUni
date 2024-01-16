namespace _03.StoreBoxes
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class Box
    {
        public string SerialNumber { get; set; }
        public string Item { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForABox { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            

            while (input == "end")
            {

            }
        }
    }
}
