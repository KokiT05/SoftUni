using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string lastProblem = string.Empty;
            int countGrades = 1;
            double gradeSum = 0;
            double averageGrades = 0;
            bool isFailed = true;
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
                        isFailed = false;
                        break;
                    }
                }

                gradeSum += evaluation;

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

            averageGrades = gradeSum / countGrades;

            if (isFailed)
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
