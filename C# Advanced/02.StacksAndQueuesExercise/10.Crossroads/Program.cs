using System.Linq;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int durationOfFreeWindow = int.Parse(Console.ReadLine());

            Queue<string> carsQueue = new Queue<string>();
            Queue<char> currentCarQueue = new Queue<char>();
            bool isOnGreenLight = true;
            int timeToPass = 0;
            int countOfPassCars = 0;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    isOnGreenLight = true;
                    timeToPass = durationOfGreenLight;
                    while (carsQueue.Count > 0)
                    {
                        string currentCarString = carsQueue.Dequeue();
                        foreach (char symbol in currentCarString)
                        {
                            currentCarQueue.Enqueue(symbol);
                        }

                        for (int i = 1; i <= timeToPass && currentCarQueue.Count > 0; i++)
                        {
                            currentCarQueue.Dequeue();

                        }

                        if (currentCarQueue.Count > 0)
                        {
                            for (int i = 1; i <= (durationOfFreeWindow + timeToPass) && currentCarQueue.Count > 0; i++)
                            {
                                currentCarQueue.Dequeue();
                            }

                            isOnGreenLight = false;
                        }

                        if (currentCarQueue.Count > 0)
                        {
                            Console.WriteLine($"A crash happened!");
                            Console
                            .WriteLine
                            ($"{currentCarString} was hit at {currentCarQueue.Peek()}.");
                            return;
                        }
                        else
                        {
                            timeToPass -= currentCarString.Length;
                            countOfPassCars++;
                        }

                        if (isOnGreenLight == false)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console
            .WriteLine
            ($"Everyone is safe.\n{countOfPassCars} total cars passed the crossroads.");
        }
    }
}
