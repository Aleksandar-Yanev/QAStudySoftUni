using System.Text.RegularExpressions;

string pattern = @"(?<day>\d{2})(?<sep>[\.|\-|\/])(?<mount>[A-Z][a-z]{2})\k<sep>(?<year>\d{4})\b";
Regex regex = new Regex(pattern);

string input = Console.ReadLine();

MatchCollection matches = Regex.Matches(input, pattern);

foreach (Match match in matches)
{
    Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["mount"]}, Year: {match.Groups["year"]}");
}