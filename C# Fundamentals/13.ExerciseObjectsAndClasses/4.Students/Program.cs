namespace _4.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();
            for (int i = 1; i <= countOfStudents; i++)
            {
                string[] information = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                CreateStudent(information, students);
            }

            PrintStudent(students);
        }

        public static void PrintStudent(List<Student> students)
        {
            students = students.OrderByDescending(s => s.Grade).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }

        public static void CreateStudent(string[] information, List<Student> students)
        {
            string firstName = information[0];
            string lastName = information[1];
            double grade = double.Parse(information[2]);
            Student student = new Student(firstName, lastName, grade);
            students.Add(student);
        }

    }

    public class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }
    }
}