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
        public Item  boxItem{ get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForABox { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> storeBox = new(); 
            
            while (input != "end")
            {
                string[] separetedInput = input.Split(" ");
                Item currentItem = new Item
                {
                    Name = separetedInput[1],
                    Price = double.Parse(separetedInput[3])
                };
                
                Box currentBox = new Box
                {
                    SerialNumber = separetedInput[0],
                    boxItem = currentItem,
                    ItemQuantity = int.Parse(separetedInput[2]),
                    PriceForABox = int.Parse(separetedInput[2]) * double.Parse(separetedInput[3])
                };
                
                storeBox.Add(currentBox);
                input = Console.ReadLine();
            }
            
            var sortedBoxes = storeBox.OrderByDescending(b => b.PriceForABox);

            foreach (var box in sortedBoxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.boxItem.Name} - ${box.boxItem.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:F2}");
            }
        }
    }
}
