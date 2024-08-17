namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int nLines = int.Parse(Console.ReadLine());

            //Queue<int> amountOfPetrolQueue = new Queue<int>();
            //Queue<int> distancesQueue = new Queue<int>();

            //for (int i = 0; i < nLines; i++)
            //{
            //    int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            //    int amountOfPetrol = inputData[0];
            //    int distance = inputData[1];

            //    amountOfPetrolQueue.Enqueue(amountOfPetrol);
            //    distancesQueue.Enqueue(distance);
            //}

            //int smallestIndex = -1;
            //int sumOfAmountPetrol = 0;
            //int sumOfDistance = 0;

            //for (int i = 0; i < nLines; i++)
            //{
            //    int valueOfAmountPetrol = amountOfPetrolQueue.Dequeue();
            //    int valueOfDistance = distancesQueue.Dequeue();

            //    sumOfAmountPetrol += valueOfAmountPetrol;
            //    sumOfDistance += valueOfDistance;

            //    if (sumOfAmountPetrol < sumOfDistance)
            //    {
            //        sumOfAmountPetrol = 0;
            //        sumOfDistance = 0;
            //        smallestIndex = i;
            //    }
            //}

            //if (smallestIndex == -1)
            //{
            //    Console.WriteLine(0);
            //}
            //else
            //{
            //    Console.WriteLine(smallestIndex + 1);
            //}

            int nLines = int.Parse(Console.ReadLine());
            Queue<string> pumpsQueue = new Queue<string>();

            for (int i = 0; i < nLines; i++)
            {
                pumpsQueue.Enqueue(Console.ReadLine());
            }


            int index = 0;

            for (int i = 0; i < nLines; i++)
            {
                bool isCompleted = true;
                int totalCapacity = 0;

                for (int j = 0; j < nLines; j++)
                {
                    string currentValue = pumpsQueue.Dequeue();
                    pumpsQueue.Enqueue(currentValue);

                    if (isCompleted)
                    {
                        string[] tokens = currentValue.Split();
                        int amount = int.Parse(tokens[0]);
                        int distance = int.Parse(tokens[1]);

                        totalCapacity += amount - distance;

                        if (totalCapacity < 0)
                        {
                            isCompleted = false;
                        }
                    }


                }

                if (isCompleted)
                {
                    index = i;
                    break;
                }

                pumpsQueue.Enqueue(pumpsQueue.Dequeue());
            }

            Console.WriteLine(index);
        }
    }
}
