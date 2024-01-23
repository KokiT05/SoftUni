using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysInWhichSpitsMoney = 0;
            int days = 0;
            double money = 0;
            string command = string.Empty;

            double moneyNeededForExcursion = double.Parse(Console.ReadLine());
            double moneyOnHand = double.Parse(Console.ReadLine());

            while (true)
            {
                command = Console.ReadLine();
                money = double.Parse(Console.ReadLine());
                days += 1;

                if (command == "saved")
                {
                    moneyOnHand += money;
                    if (moneyOnHand >= moneyNeededForExcursion)
                    {
                        Console.WriteLine($"You saved the money for {days} days.");
                        break;
                    }
                    daysInWhichSpitsMoney = 0;
                }
                else if (command == "spend")
                {
                    daysInWhichSpitsMoney++;
                    if (daysInWhichSpitsMoney == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine($"{daysInWhichSpitsMoney}");
                        break;
                    }

                    if (money >= moneyOnHand)
                    {
                        moneyOnHand = 0;
                    }
                    else if (moneyOnHand > 0)
                    {
                        moneyOnHand -= money;
                    }
                }
            }
        }
    }
}
