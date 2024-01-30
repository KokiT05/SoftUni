using System;

namespace _05.Series
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalPriceForActor = 0;
            double priceForActor = 0;

            double budgetActors = double.Parse(Console.ReadLine());

            while (budgetActors > 0)
            {
                string actorName = Console.ReadLine();

                if (actorName == "ACTION")
                {
                    break;
                }

                if (actorName.Length > 15)
                {
                    budgetActors =  budgetActors - (budgetActors * 0.20);
                }
                else if (actorName.Length <= 15)
                {
                    double reward = double.Parse(Console.ReadLine());
                    totalPriceForActor += reward;
                }

                budgetActors -= totalPriceForActor;
            }

            if (budgetActors < 0)
            {
                Console.WriteLine($"We need {budgetActors} leva for our actors.");
            }
            else
            {
                Console.WriteLine($"We are left with {budgetActors} leva.");
            }
        }
    }
}
