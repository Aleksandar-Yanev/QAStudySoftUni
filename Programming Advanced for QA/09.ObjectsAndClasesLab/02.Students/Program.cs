namespace _02.Students
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }    
        public string HomeTown { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> listOfStudents = new List<Student>();

            while (input != "end")
            {
                string[] studentData = input.Split(" ").ToArray();
                Student currentStudent = new Student() 
                {
                    FirstName = studentData[0],
                    LastName = studentData[1],
                    Age = int.Parse(studentData[2]),
                    HomeTown = studentData[3]
                };

                listOfStudents.Add(currentStudent);

                input = Console.ReadLine();
            }

            string sity = Console.ReadLine();
            listOfStudents = listOfStudents.Where(x => x.HomeTown == sity).ToList();
            foreach (Student student in listOfStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " is " + student.Age + " years old.");
            }
           
        }
    }
}