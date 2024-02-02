namespace _04.Back_In_30_Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutesToBack = 30;

            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            int totalMinutes = minutes + minutesToBack;

            if (totalMinutes >= 60)
            {
                totalMinutes -= 60;
                hours++;

                if (hours > 23)
                {
                    hours = 0;
                }
            }

            if (totalMinutes < 10)
            {
                Console.WriteLine($"{hours}:0{totalMinutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{totalMinutes}");
            }
        }
    }
}