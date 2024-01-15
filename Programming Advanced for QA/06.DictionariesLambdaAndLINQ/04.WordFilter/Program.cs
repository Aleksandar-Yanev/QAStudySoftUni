string[] input = Console.ReadLine()
    .Split(" ")
    .ToArray();

Dictionary <string, int> output = new Dictionary<string, int>();

foreach (string word in input)
{
    output[word] = word.Length;
}

foreach (var word in output)
{
    if (word.Value % 2 == 0)
    {
        Console.WriteLine(word.Key);
    }
}