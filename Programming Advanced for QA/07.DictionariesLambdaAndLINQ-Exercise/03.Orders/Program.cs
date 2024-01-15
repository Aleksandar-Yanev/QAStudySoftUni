string [] input = Console.ReadLine().Split(" ").ToArray();
Dictionary <string, List<decimal>>  products = new();

while (input[0] != "buy")
{
    string productName = input[0];
    decimal price = Decimal.Parse(input[1]);
    decimal quantity = Decimal.Parse(input[2]);

    if (products.ContainsKey(productName))
    {
        products[productName][0] = price;
        products[productName][1] += quantity;
    }
    else
    {
        products.Add(productName, new List<decimal> { price, quantity });
    }
    
    input = Console.ReadLine().Split(" ").ToArray();
}

foreach(var product in products)
{
    decimal totalPrice = product.Value[0] * product.Value[1];
    Console.WriteLine($"{product.Key} -> {totalPrice:F2}");
}