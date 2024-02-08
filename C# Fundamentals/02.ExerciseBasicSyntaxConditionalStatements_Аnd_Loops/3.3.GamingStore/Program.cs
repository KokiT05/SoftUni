using System;

namespace _3._3.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool currentBalanceIsZero = false;
            bool isExist = true;
            double priceSpentOnGames = 0;
            double priceOfGame = 0;

            double currentBalance = double.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Game Time")
            {

                if (command == "OutFall 4")
                {
                    priceOfGame = 39.99;
                    isExist = true;
                }
                else if (command == "CS: OG")
                {
                    priceOfGame = 15.99;
                    isExist = true;
                }
                else if (command == "Zplinter Zell")
                {
                    priceOfGame = 19.99;
                    isExist = true;
                }
                else if (command == "Honored 2")
                {
                    priceOfGame = 59.99;
                    isExist = true;
                }
                else if (command == "RoverWatch")
                {
                    priceOfGame = 29.99;
                    isExist = true;
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    priceOfGame = 39.99;
                    isExist = true;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    isExist = false;
                }


                if (priceOfGame > currentBalance)
                {
                    Console.WriteLine("Too Expensive");
                }

                if (isExist && priceOfGame <= currentBalance)
                {
                    currentBalance -= priceOfGame;
                    priceSpentOnGames += priceOfGame;

                    Console.WriteLine($"Bought {command}");
                }

                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    currentBalanceIsZero = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (!currentBalanceIsZero)
            {
                Console.WriteLine($"Total spent: ${priceSpentOnGames:f2}. Remaining: ${currentBalance:f2}");
            }
        }
    }
}
