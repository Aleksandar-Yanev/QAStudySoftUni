using System.ComponentModel.DataAnnotations;

List<int> listOfNumbers = Console.ReadLine()
    .Split(' ')
    .Select(int.Parse)
    .ToList();

int counOfRotation = int.Parse(Console.ReadLine());

for (int i = 0; i < counOfRotation; i++)
{
    int lastElement = listOfNumbers[listOfNumbers.Count - 1];
    listOfNumbers.RemoveAt(listOfNumbers.Count - 1);
    listOfNumbers.Insert(0, lastElement);
}

string result = string.Join(", ", listOfNumbers);
Console.WriteLine(result);
