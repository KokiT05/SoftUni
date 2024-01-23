using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool flag = false;
            int allSteps = 0;
            int stepsToHome = 0;

            string steps = string.Empty;
            steps = steps.ToLower();

            while (allSteps <= 10_000 && steps != "going home")
            {
                steps = Console.ReadLine();
                steps = steps.ToLower();
                

                if (steps == "going home")
                {
                    stepsToHome = int.Parse(Console.ReadLine());
                    allSteps += stepsToHome;
                    break;
                }
                allSteps += int.Parse(steps);
            }


            int result = Math.Abs(allSteps - 10_000);

            if (allSteps >= 10_000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{result} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{result} more steps to reach goal.");
            }
        }
    }
}
