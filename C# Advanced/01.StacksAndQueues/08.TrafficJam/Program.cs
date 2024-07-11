namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int sumOfPassedCars = 0;

            int countPass = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "end") 
            {
                if (input == "green")
                {
                    for (int i = 1; i <= countPass; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        sumOfPassedCars++;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{sumOfPassedCars} cars passed the crossroads.");
        }
    }
}
