using System;

namespace _03.OscarsWeekINCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double price = 0;
            double totalPrice = 0;

            string movieName = Console.ReadLine();
            string typeOfHall = Console.ReadLine();
            int numberOfTicketsPurchased = int.Parse(Console.ReadLine());

            if (movieName == "A Star Is Born")
            {
                if (typeOfHall == "normal")
                {
                    price = 7.50;
                }
                else if (typeOfHall == "luxury")
                {
                    price = 10.50;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    price = 13.50;
                }
            }
            else if (movieName == "Bohemian Rhapsody")
            {
                if (typeOfHall == "normal")
                {
                    price = 7.35;
                }
                else if (typeOfHall == "luxury")
                {
                    price = 9.45;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    price = 12.75;
                }
            }
            else if (movieName == "Green Book")
            {
                if (typeOfHall == "normal")
                {
                    price = 8.15;
                }
                else if (typeOfHall == "luxury")
                {
                    price = 10.25;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    price = 13.25;
                }
            }
            else if (movieName == "The Favourite")
            {
                if (typeOfHall == "normal")
                {
                    price = 8.75;
                }
                else if (typeOfHall == "luxury")
                {
                    price = 11.55;
                }
                else if (typeOfHall == "ultra luxury")
                {
                    price = 13.95;
                }
            }

            totalPrice = price * numberOfTicketsPurchased;

            Console.WriteLine($"{movieName} -> {totalPrice:f2} lv.");
        }
    }
}
