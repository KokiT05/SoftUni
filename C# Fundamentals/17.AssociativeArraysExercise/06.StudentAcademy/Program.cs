namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> studentGrade = new Dictionary<string, List<double>>(row);
            for (int i = 0; i < row; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (studentGrade.ContainsKey(studentName) == false)
                {
                    studentGrade.Add(studentName, new List<double> { grade });
                }
                else
                {
                    studentGrade[studentName].Add(grade);
                }
            }

            studentGrade = studentGrade.Where(v => v.Value.Average() >= 4.50)
                /*.OrderByDescending(v => v.Value.Average())*/.ToDictionary(k => k.Key, v => v.Value);

            foreach (string studentName in studentGrade.Keys)
            {
                Console.WriteLine($"{studentName} -> {studentGrade[studentName].Average():f2}");
            }
        }
    }
}