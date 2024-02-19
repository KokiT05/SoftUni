using System;

namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentYield = 0;
            int workersConsume = 26;
            int totalAmountOfYield = 0;
            int day = 0;

            int startingYield = int.Parse(Console.ReadLine());
            currentYield = startingYield;

            while (currentYield >= 100)
            {
                day++;
                totalAmountOfYield += (currentYield - workersConsume);
                currentYield -= 10;
            }


            if (totalAmountOfYield >= 26)
            {
                totalAmountOfYield -= workersConsume;
            }

            Console.WriteLine($"{day}");
            Console.WriteLine($"{totalAmountOfYield}");
        }
    }
}
