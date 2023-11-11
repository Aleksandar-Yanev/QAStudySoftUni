string [] input = Console.ReadLine()
    .Split(" ");
string concatenatedString = "";

for (int i = 0; i < input.Length; i++)
{
    string element = input[i];

    for (int j = 0; j < element.Length; j++)
    {
        concatenatedString += element;
    }
}

Console.WriteLine(concatenatedString);
