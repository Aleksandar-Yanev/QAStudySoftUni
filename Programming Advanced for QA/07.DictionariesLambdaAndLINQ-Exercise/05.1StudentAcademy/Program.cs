Dictionary<string, List<double>> students = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string studentName = Console.ReadLine();
    double studentGrade = double.Parse(Console.ReadLine());

    if (!students.ContainsKey(studentName))
    {
        students.Add(studentName, new List<double>());
    }

    students[studentName].Add(studentGrade);
}

var exelentStudents = students.Where(kvp => kvp.Value.Average () >= 4.50);
foreach (var student in exelentStudents)
{
    Console.WriteLine($"{student.Key} -> {student.Value.Average():F2}");
}