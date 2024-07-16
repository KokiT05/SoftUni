using System.Linq;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int greenLightSeconds = int.Parse(Console.ReadLine());
            //int secondsPassCrossroad = int.Parse(Console.ReadLine());

            //Queue<string> carsQueue = new Queue<string>();
            //int counter = 0;

            //while (true)
            //{
            //    string car = Console.ReadLine();

            //    int greenLights = greenLightSeconds;
            //    int passSeconds = secondsPassCrossroad;
            //    if (car == "END")
            //    {
            //        Console.WriteLine($"Everyone is safe.{Environment.NewLine}" +
            //                $"{counter} total cars passed the crossroads.");
            //        return;
            //    }

            //    if (car == "green")
            //    {
            //        while (greenLights > 0 && carsQueue.Count > 0)
            //        {

            //            string firstInQueue = carsQueue.Dequeue();
            //            greenLights -= firstInQueue.Length;
            //            if (greenLights >= 0)
            //            {
            //                counter++;
            //            }
            //            else
            //            {
            //                passSeconds += greenLights;
            //                if (passSeconds < 0)
            //                {
            //                    Console.WriteLine($"A crash happened!{Environment.NewLine}" +
            //                        $"{firstInQueue} was hit at" +
            //                        $" {firstInQueue[firstInQueue.Length + passSeconds]}.");
            //                    return;
            //                }
            //                counter++;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        carsQueue.Enqueue(car);
            //    }
            //}


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

                        if (currentCarQueue.Count > 0 && timeToPass != 0)
                        {
                            for (int i = 1; i <= durationOfFreeWindow && currentCarQueue.Count > 0; i++)
                            {
                                currentCarQueue.Dequeue();
                            }

                            isOnGreenLight = false;
                        }

                        if (currentCarQueue.Count > 0 && timeToPass > 0)
                        {
                            Console.WriteLine($"A crash happened!");
                            Console
                            .WriteLine
                            ($"{currentCarString} was hit at {currentCarQueue.Peek()}.");
                            return;
                        }
                        else if (timeToPass > 0)
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
            ($"Everyone is safe.{Environment.NewLine}{countOfPassCars} total cars passed the crossroads.");
        }
    }
}
