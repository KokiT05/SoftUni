namespace _4.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] information = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                students.Add(NewStudent(information));

                command = Console.ReadLine();
            }

            string town = Console.ReadLine();

            students = students.Where(s => s.HomeTown == town).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

        public static Student NewStudent(string[] information)
        {
            string firstName = information[0];
            string lastName = information[1];
            int age = int.Parse(information[2]);
            string homeTown = information[3];

            Student student = new Student(firstName, lastName, age, homeTown);
            return student;
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.HomeTown = homeTown;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

    }
}