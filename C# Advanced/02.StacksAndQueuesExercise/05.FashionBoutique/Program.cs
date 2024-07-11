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
        }
    }
}
