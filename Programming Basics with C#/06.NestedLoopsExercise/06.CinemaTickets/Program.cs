namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalStudentSeats = 0;
            double totalKidSeats = 0;
            double totalStandardSeats = 0;

            int totalTickets = 0;

            double precentFilled = 0;
            double occupiedSeats = 0;

            double percentStudentTickets = 0;
            double percentKidTickets = 0;
            double percentStandardTickets = 0;

            int freeSeats = 0;
            string command = string.Empty;

            string moviName = Console.ReadLine();

            while (moviName != "Finish")
            {
                freeSeats = int.Parse(Console.ReadLine());

                precentFilled = 0;
                occupiedSeats = 0;

                for (int i = 1; i <= freeSeats; i++)
                {
                    if (freeSeats <= 0)
                    {
                        break;
                    }

                    command = Console.ReadLine();

                    if (command == "End")
                    {
                        break;
                    }
                    else if (command == "standard")
                    {
                        totalStandardSeats++;
                        occupiedSeats++;
                    }
                    else if (command == "kid")
                    {
                        totalKidSeats++;
                        occupiedSeats++;
                    }
                    else if (command == "student")
                    {
                        totalStudentSeats++;
                        occupiedSeats++;
                    }
                    totalTickets++;
                }
                precentFilled = (occupiedSeats / freeSeats) * 100;
                Console.WriteLine($"{moviName} - {precentFilled:f2}% full.");
                moviName = Console.ReadLine();
            }
            percentKidTickets = (totalKidSeats / totalTickets) * 100;
            percentStandardTickets = (totalStandardSeats / totalTickets) * 100;
            percentStudentTickets = (totalStudentSeats / totalTickets) * 100;


            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{percentStudentTickets:f2}% student tickets.");
            Console.WriteLine($"{percentStandardTickets:f2}% standard tickets.");
            Console.WriteLine($"{percentKidTickets:f2}% kids tickets.");

        }
    }
}