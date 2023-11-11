char[] input = Console.ReadLine().ToArray();
string digit = "";
string letter = "";
string other = "";

foreach (char character in input)
{
    if (Char.IsDigit(character))
    {
        digit += character;
    }
    else if (Char.IsLetter(character))
    {
         letter += character;
    }
    else
    {
        other += character;
    }
}

Console.WriteLine(digit);
Console.WriteLine(letter);
Console.WriteLine(other);