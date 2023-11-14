using System.ComponentModel;

int number = int.Parse(Console.ReadLine());
Dictionary <string, List<string>> synonims = new Dictionary<string, List<string>>();

for  (int i = 0; i < number; i++)
{
    string word = Console.ReadLine();
    string sinonim = Console.ReadLine();

    if (synonims.ContainsKey(word))
    {
        synonims[word].Add(sinonim);
    }
    else
    {
        synonims[word] = new List<string> { sinonim };
    }
}

foreach (var word in synonims)
{
    Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
}