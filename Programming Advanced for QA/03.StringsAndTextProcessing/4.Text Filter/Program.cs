string [] bannedWods = Console.ReadLine().Split(", ");
string text = Console.ReadLine();


foreach (string bannedWord in bannedWods)
{
    string replasment = "";

    for (int i = 0; i < bannedWord.Length; i++)
    {
        replasment += "*";
    }

    while (text.Contains(bannedWord))
    {
        text = text.Replace(bannedWord, replasment);
    }
}
Console.WriteLine(text);
