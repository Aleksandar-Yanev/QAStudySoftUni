int[] arrayOfNumbers = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToArray();

int countOfRotations = int.Parse(Console.ReadLine());

for (int i = 0; i < countOfRotations; i++)
{
    int lastElement = arrayOfNumbers[arrayOfNumbers.Length - 1];

    for (int j = arrayOfNumbers.Length - 1; j > 0; j--)
    {
        arrayOfNumbers[j] = arrayOfNumbers[j - 1];
    }

    arrayOfNumbers[0] = lastElement;
}

string result = string.Join(", ", arrayOfNumbers);
Console.WriteLine(result);
