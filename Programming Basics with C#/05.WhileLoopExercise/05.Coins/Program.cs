using System;

namespace _05.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int coins = 0;

            double money = double.Parse(Console.ReadLine());
            money = Math.Round(money, 2);
            while (money != 0)
            {
                money = Math.Round(money, 2);
                if (money >= 2)
                {
                    money -= 2;
                    coins++;
                }
                else if (money >= 1)
                {
                    money -= 1;
                    coins++;
                }
                else if (money >= 0.50)
                {
                    money -= 0.50;
                    coins++;
                }
                else if (money >= 0.20)
                {
                    money -= 0.20;
                    coins++;
                }
                else if (money >= 0.10)
                {
                    money -= 0.10;
                    coins++;
                }
                else if (money >= 0.05)
                {
                    money -= 0.05;
                    coins++;
                }
                else if (money >= 0.02)
                {
                    money -= 0.02;
                    coins++;
                }
                else if (money >= 0.01)
                {
                    money -= 0.01;
                    coins++;
                }
            }

            Console.WriteLine(coins);
        }
    }
}
