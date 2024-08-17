namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothesQueue = new Stack<int>(clothes);
            int capacityOfRack = int.Parse(Console.ReadLine());
            int sumOfClothes = 0;
            int countOfRack = 1;

            while (clothesQueue.Count > 0)
            {
                int valueOfClothes = clothesQueue.Pop();
                if (valueOfClothes + sumOfClothes <= capacityOfRack)
                {
                    sumOfClothes += valueOfClothes;
                }
                else
                {
                    sumOfClothes = valueOfClothes;
                    countOfRack++;
                }
            }


            Console.WriteLine(countOfRack);

            int[] allClothesInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> allClothesStack = new Stack<int>(allClothesInput);

            int boxCapacity = int.Parse(Console.ReadLine());
            int currentRackCapacity = boxCapacity;
            int racksCount = 1;

            while (allClothesStack.Any())
            {
                int clothesS = allClothesStack.Pop();
                currentRackCapacity -= clothesS;

                if (currentRackCapacity < 0)
                {
                    racksCount++;
                    currentRackCapacity = boxCapacity - clothesS;
                }
            }

            Console.WriteLine(racksCount);


        }
    }
}
