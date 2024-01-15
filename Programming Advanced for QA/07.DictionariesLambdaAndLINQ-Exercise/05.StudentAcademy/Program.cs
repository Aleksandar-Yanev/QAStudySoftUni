using System.ComponentModel;

Dictionary<string, List<double>> students = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string studentName = Console.ReadLine();
    double studentGrade = double.Parse(Console.ReadLine());

    if (!students.ContainsKey(studentName))
    {
        students[studentName] = new List<double> { studentGrade };
    }
    else
    {
        students[studentName].Add(studentGrade);
    }
}

foreach (var student in students)
{
    double averageGrade = 0;

    for (int i = 0; i < student.Value.Count; i++)
    {
        averageGrade += student.Value[i]; 

    }

    averageGrade /= student.Value.Count;

    if (averageGrade >= 4.50)
    {
        Console.WriteLine($"{student.Key} -> {averageGrade:F2}");
    }
}