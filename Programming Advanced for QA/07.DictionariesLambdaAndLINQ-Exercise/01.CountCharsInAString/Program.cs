// char[] textToChar = Console.ReadLine().ToCharArray();
string inputText = Console.ReadLine();

Dictionary <char, int> chars = new Dictionary<char, int>();

foreach (char ch in inputText)
{
    if (ch == ' ')
    {
        continue;
    }
    else if (chars.ContainsKey(ch))
    {
        chars[ch]++;
    }
    else
    {
        chars.Add(ch, 1);
    }
}

foreach ( var character in chars)
{
    Console.WriteLine($"{character.Key} -> {character.Value}");
}