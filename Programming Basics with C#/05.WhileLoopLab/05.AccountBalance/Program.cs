using System;

namespace _05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double money = 0;
            double sum = 0;

            string command = Console.ReadLine();

            while (command != "NoMoreMoney")
            {

                money = double.Parse(command);
                if (money >= 0)
                {
                    sum += money;
                    Console.WriteLine($"Increase: {money:f2}");
                }
                else
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                command = Console.ReadLine();

            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
