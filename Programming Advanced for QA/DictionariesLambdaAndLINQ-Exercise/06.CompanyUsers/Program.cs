Dictionary<string, List<string>> companyUsers = new();

string input = Console.ReadLine();

while (input != "End")
{
    List<string> inputcompanyData = input.Split(" -> ").ToList();
    string companyName = inputcompanyData[0];
    string emploeeId = inputcompanyData[1];

    if (!companyUsers.ContainsKey(companyName))
    {
        companyUsers[companyName] = new List<string>();
    }

    if (!companyUsers[companyName].Contains(emploeeId))
    {
        companyUsers[companyName].Add(emploeeId);
    }

    input = Console.ReadLine();
}

foreach (var kvp  in companyUsers)
{
    Console.WriteLine(kvp.Key);
    for (int i = 0; i < kvp.Value.Count; i++)
    {
        Console.WriteLine($"-- {kvp.Value[i]}");
    }
}