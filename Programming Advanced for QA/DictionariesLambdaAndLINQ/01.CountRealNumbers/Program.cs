using System.Threading.Tasks.Dataflow;

List<int> numbers = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToList();

SortedDictionary<int, int> result = new ();

foreach (var number in numbers)
{
    if (result.ContainsKey(number))
    {
        result[number] += 1;
    }
    else 
    { 
        result[number] = 1; 
    }
}
foreach (var output in result)
Console.WriteLine($"{output.Key} -> {output.Value}");