using System;

namespace _11.FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double banana = 0;
            double apple = 0;
            double orange = 0;
            double grapefruit = 0;
            double kiwi = 0;
            double pineapple = 0;
            double grapes = 0;
            double price = 0;

            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            fruit = fruit.ToLower();
            dayOfWeek = dayOfWeek.ToLower();

            if (dayOfWeek == "saturday" || dayOfWeek == "sunday")
            {
                banana = 2.70;
                apple = 1.25;
                orange = 0.90;
                grapefruit = 1.60;
                kiwi = 3.00;
                pineapple = 5.60;
                grapes = 4.20;

                switch (fruit)
                {
                    case "banana":
                        price = banana * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "apple":
                        price = apple * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "orange":
                        price = orange * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapefruit":
                        price = grapefruit * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "kiwi":
                        price = kiwi * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "pineapple":
                        price = pineapple * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapes":
                        price = grapes * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else if (dayOfWeek == "monday" || dayOfWeek == "tuesday" || dayOfWeek == "wednesday"
                || dayOfWeek == "thursday" || dayOfWeek == "friday")
            {
                banana = 2.50;
                apple = 1.20;
                orange = 0.85;
                grapefruit = 1.45;
                kiwi = 2.70;
                pineapple = 5.50;
                grapes = 3.85;

                switch (fruit)
                {
                    case "banana":
                        price = banana * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "apple":
                        price = apple * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "orange":
                        price = orange * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapefruit":
                        price = grapefruit * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "kiwi":
                        price = kiwi * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "pineapple":
                        price = pineapple * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    case "grapes":
                        price = grapes * amount;
                        Console.WriteLine($"{price:f2}");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
