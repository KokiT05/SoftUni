using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lastProblem = string.Empty;
            int countGrades = 1;
            double allGrades = 0;
            double averageGrades = 0;
            bool flag = true;
            int countInsatisfactoryGrades = 0;

            int numberOfUnsatisfactoryGrades = int.Parse(Console.ReadLine());

            string problem = Console.ReadLine();
            double evaluation = double.Parse(Console.ReadLine());

            while (true)
            {
                if (evaluation <= 4)
                {
                    countInsatisfactoryGrades++;

                    if (countInsatisfactoryGrades == numberOfUnsatisfactoryGrades)
                    {
                        flag = false;
                        break;
                    }
                }

                allGrades += evaluation;

                problem = Console.ReadLine();

                if (problem == "Enough")
                {
                    break;
                }
                else
                {
                    lastProblem = problem;
                }
                evaluation = double.Parse(Console.ReadLine());
                countGrades++;
            }

            averageGrades = allGrades / countGrades;

            if (flag)
            {
                Console.WriteLine($"Average score: {averageGrades:f2}");
                Console.WriteLine($"Number of problems: {countGrades}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {countInsatisfactoryGrades} poor grades.");
            }
        }
    }
}
