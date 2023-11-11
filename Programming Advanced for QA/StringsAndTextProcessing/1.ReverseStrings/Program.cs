using System.Runtime.InteropServices;
using System.Xml;

string input = Console.ReadLine();

while (input != "end")
{
    char[] inputChar = input.ToCharArray();

    Array.Reverse(inputChar);

    string reversedInput = new string(inputChar);

    Console.WriteLine($"{input} = {reversedInput}");

    input = Console.ReadLine();
}

