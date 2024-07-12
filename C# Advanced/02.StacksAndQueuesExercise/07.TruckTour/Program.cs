namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nLines = int.Parse(Console.ReadLine());

            Queue<int> amountOfPetrolQueue = new Queue<int>();
            Queue<int> distancesQueue = new Queue<int>();

            for (int i = 0; i < nLines; i++)
            {
                int[] inputData = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int amountOfPetrol = inputData[0];
                int distance = inputData[1];

                amountOfPetrolQueue.Enqueue(amountOfPetrol);
                distancesQueue.Enqueue(distance);
            }

            int smallestIndex = -1;
            int sumOfAmountPetrol = 0;
            int sumOfDistance = 0;

            int[] incorrectIndex = new int[nLines];
            int count = 0;
            for (int i = 0; i < nLines; i++)
            {
                int valueOfAmountPetrol = amountOfPetrolQueue.Dequeue();
                int valueOfDistance = distancesQueue.Dequeue();

                amountOfPetrolQueue.Enqueue(valueOfAmountPetrol);
                distancesQueue.Enqueue(valueOfDistance);

                sumOfAmountPetrol += valueOfAmountPetrol;
                sumOfDistance += valueOfDistance;

                if (sumOfAmountPetrol < sumOfDistance)
                {
                    incorrectIndex[count] = i;
                    sumOfAmountPetrol = 0;
                    sumOfDistance = 0;
                    smallestIndex = i;
                }
                count++;
            }

            if (smallestIndex == -1)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(smallestIndex + 1);
            }
        }
    }
}
