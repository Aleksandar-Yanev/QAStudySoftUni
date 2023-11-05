int numberOfStudents = int.Parse(Console.ReadLine());
double averidgeGrade = 0;
double studentGrade = 0;

for  (int i = 0; i < numberOfStudents; i++)
{
    // studentGrade = double.Parse(Console.ReadLine());
    studentGrade += double.Parse(Console.ReadLine());
}
averidgeGrade = studentGrade / numberOfStudents;
Console.WriteLine($"{averidgeGrade:F2}");
// 