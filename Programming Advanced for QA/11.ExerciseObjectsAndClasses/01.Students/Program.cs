
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace _01.Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       public double Grade { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < n; i++)
            {
                string [] input = Console.ReadLine().Split().ToArray();
                
                Student student = new Student
                {
                    FirstName = input[0],
                    LastName = input[1],
                    Grade = double.Parse(input[2])
                };

                students.Add(student);
            }
            List<Student> sortedStudents = students.OrderByDescending(s => s.Grade).ToList();

            foreach (Student student in sortedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }
        }
        
    }
}