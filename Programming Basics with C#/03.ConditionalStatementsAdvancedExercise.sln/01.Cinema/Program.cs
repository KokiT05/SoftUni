using System;
using System.Runtime.CompilerServices;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double premiere = 12.00;
            double normal = 7.50;
            double discount = 5.00;
            double totalTicketRevenue = 0;
            double totalSeats = 0;

            string filmScreening = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            totalSeats = r * c;

            filmScreening = filmScreening.ToLower();

            if (filmScreening == "premiere")
            {
                totalTicketRevenue = totalSeats * premiere;
            }
            else if (filmScreening == "normal")
            {
                totalTicketRevenue = totalSeats * normal;
            }
            else if (filmScreening == "discount")
            {
                totalTicketRevenue = totalSeats * discount;
            }

            if (!(totalTicketRevenue <= 0))
            {
                Console.WriteLine($"{totalTicketRevenue:f2} leva");
            }
        }
    }
}
