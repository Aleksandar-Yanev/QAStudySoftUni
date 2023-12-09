using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, (double price, int quantity)> products = new Dictionary<string, (double, int)>();

        string input;
        while ((input = Console.ReadLine()) != "buy")
        {
            string[] inputTokens = input.Split();
            string productName = inputTokens[0];
            double productPrice = double.Parse(inputTokens[1]);
            int productQuantity = int.Parse(inputTokens[2]);

            if (products.ContainsKey(productName))
            {
                // Product already exists, update price and quantity
                var (price, quantity) = products[productName];
                products[productName] = (productPrice, quantity + productQuantity);
            }
            else
            {
                // Product doesn't exist, add it to the dictionary
                products.Add(productName, (productPrice, productQuantity));
            }
        }

        // Print information about each product
        foreach (var kvp in products)
        {
            string productName = kvp.Key;
            var (price, quantity) = kvp.Value;
            double totalPrice = price * quantity;
            Console.WriteLine($"{productName} -> {totalPrice:F2}");
        }
    }
}
