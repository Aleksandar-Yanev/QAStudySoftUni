using System.Text.RegularExpressions;

string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
Regex regex = new Regex(pattern);

string input = Console.ReadLine();

MatchCollection matches = Regex.Matches(input, pattern);

foreach (Match match in matches)
{
    Console.Write(match.Value + " ");
}