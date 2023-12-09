using System.Resources;

string resource = Console.ReadLine();
Dictionary<string, int> resources = new Dictionary<string, int>();

while (resource != "stop")
{
    int quantity = int.Parse(Console.ReadLine()); 

    if (resources.ContainsKey(resource))
    {
        resources[resource] += quantity;  
    }
    else
    {
        resources.Add(resource, quantity);
    }
      
    resource = Console.ReadLine();
}

foreach (var amountOfResources in resources)
{
    Console.WriteLine($"{amountOfResources.Key} -> {amountOfResources.Value}");
}