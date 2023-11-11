string firstString = Console.ReadLine();
string secondString = Console.ReadLine();

while (secondString.Contains(firstString))
{
    secondString = secondString.Replace(firstString, "");
}
Console.WriteLine(secondString);
