int n = int.Parse(Console.ReadLine());
var words = new Dictionary<string, List<string>>();
for (int i = 0; i < n; i++)
{
    string word = Console.ReadLine();
    string synonim = Console.ReadLine();

    if (words.ContainsKey(word) == false)
    {
        words.Add(word, new List<string>());
    }
    words[word].Add(synonim);
}
foreach (var word in words)
{
    Console.WriteLine($"{word.Key} - {string.Join(", ", word.Value)}");
}