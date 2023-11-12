using System.Text.RegularExpressions;

string pattern = @"\+359(?<sep>[ |\-])2\k<sep>\d{3}\k<sep>\d{4}\b";
Regex regex = new Regex(pattern);

string input = Console.ReadLine();

MatchCollection matches = Regex.Matches(input, pattern);

Console.WriteLine(string.Join(", ", matches));