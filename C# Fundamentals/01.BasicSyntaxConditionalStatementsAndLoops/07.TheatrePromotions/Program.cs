namespace _07.TheatrePromotions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double ticketPrice = 0;


            string typeOfDay = Console.ReadLine();
            int ageOfPerson = int.Parse(Console.ReadLine());

            if (typeOfDay == "Weekday")
            {
                if ((ageOfPerson >= 0 && ageOfPerson <= 18)
                    || (ageOfPerson > 64 && ageOfPerson <= 122))
                {
                    ticketPrice = 12;
                }
                else if (ageOfPerson > 18 && ageOfPerson <= 64)
                {
                    ticketPrice = 18;
                }
            }
            else if (typeOfDay == "Weekend")
            {
                if ((ageOfPerson >= 0 && ageOfPerson <= 18)
                    || (ageOfPerson > 64 && ageOfPerson <= 122))
                {
                    ticketPrice = 15;
                }
                else if (ageOfPerson > 18 && ageOfPerson <= 64)
                {
                    ticketPrice = 20;
                }
            }
            else if (typeOfDay == "Holiday")
            {
                if (ageOfPerson >= 0 && ageOfPerson <= 18)
                {
                    ticketPrice = 5;
                }
                else if (ageOfPerson > 18 && ageOfPerson <= 64)
                {
                    ticketPrice = 12;
                }
                else if (ageOfPerson > 64 && ageOfPerson <= 122)
                {
                    ticketPrice = 10;
                }
            }

            if (ticketPrice != 0)
            {
                Console.WriteLine($"{ticketPrice}$");
            }
            else
            {
                Console.WriteLine($"Error!");
            }
        }
    }
}