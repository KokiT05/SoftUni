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
                    sumOfPassedCars = sumOfPassedCars + countPass;

                    for (int i = 1; i <= countPass; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                }

                cars.Enqueue(input);

                input = Console.ReadLine();
            }

            Console.WriteLine($"{sumOfPassedCars} cars passed the crossroads.");
        }
    }
}
