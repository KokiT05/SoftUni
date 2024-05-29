namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> coursesStudents = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] cmdArg = input.Split(" : ");
                string course = cmdArg[0];
                string student = cmdArg[1];

                if (coursesStudents.ContainsKey(course) == false)
                {
                    coursesStudents.Add(course, new List<string> { student });
                }
                else
                {
                    coursesStudents[course].Add(student);
                }

                input = Console.ReadLine();
            }

            coursesStudents = coursesStudents.OrderByDescending(v => v.Value.Count)
                                            .ToDictionary(k => k.Key, v => v.Value);

            foreach (string courseStudent in coursesStudents.Keys)
            {
                Console.WriteLine($"{courseStudent}: {coursesStudents[courseStudent].Count}");

                Console.
                WriteLine
                ($"-- {string.Join($"\n-- ", coursesStudents[courseStudent].OrderBy(v => v))}");
            }
        }
    }
}