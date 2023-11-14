List<string> input = Console.ReadLine()
    .Split(" ")
    .ToList();

Dictionary<string, int> output = new Dictionary<string, int>();

foreach (string inputItem in input)
{
    string inputlToLower = inputItem.ToLower();

    if (output.ContainsKey(inputlToLower))
    {
        output[inputlToLower] += 1; 
    }
    else
    {
        output[inputlToLower] = 1;
    }
}
foreach (var inputlToLower in output)
{
    if (inputlToLower.Value % 2 != 0)
    {
        Console.Write($"{inputlToLower.Key} ");
    }
}