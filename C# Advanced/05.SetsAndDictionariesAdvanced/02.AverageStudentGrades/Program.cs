using System.Globalization;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            int countOfStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsGrade = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < countOfStudents; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string name = inputData[0];
                decimal grade = decimal.Parse(inputData[1]);

                if (!studentsGrade.ContainsKey(name))
                {
                    studentsGrade.Add(name, new List<decimal>());
                }

                studentsGrade[name].Add(grade);
            }   

            decimal gradesSum = 0;
            foreach (KeyValuePair<string, List<decimal>> student in studentsGrade)
            {
                gradesSum = 0;
                Console.Write($"{student.Key} -> ");
                foreach (decimal grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                    gradesSum += grade;
                }
                Console.WriteLine($"(avg: {(gradesSum / studentsGrade[student.Key].Count):f2})");
            }
        }
    }
}
