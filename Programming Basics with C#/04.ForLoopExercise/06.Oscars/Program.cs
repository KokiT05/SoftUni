using System;

namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double nomination = 1250.5;
            double totalPoints = 0;
            bool flag = true;


            string actorName = Console.ReadLine();
            double academyPoints = double.Parse(Console.ReadLine());
            int numberOfAssesors = int.Parse(Console.ReadLine());

            totalPoints = totalPoints + academyPoints;

            for (int i = 1; i < numberOfAssesors; i++)
            {
                string appraiserName = Console.ReadLine();
                double pointsFromEvaluator = double.Parse(Console.ReadLine());

                totalPoints = totalPoints + ((appraiserName.Length * pointsFromEvaluator) / 2);

                if (totalPoints > nomination)
                {
                    flag = false;
                    Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {totalPoints:f1}");
                }
            }

            if (!flag)
            {
                Console.WriteLine($"Sorry, {actorName} you need {totalPoints - nomination} more!");
            }
        }
    }
}
