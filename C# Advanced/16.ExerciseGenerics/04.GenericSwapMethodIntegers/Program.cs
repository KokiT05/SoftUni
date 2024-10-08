namespace _04.GenericSwapMethodIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> list = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int inputBox = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(inputBox);
                list.Add(box);
            }

            int[] indices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = indices[0];
            int secondIndex = indices[1];

            SpawTwoMethod<int>(firstIndex, secondIndex, list);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
        }

        public static void SpawTwoMethod<T>(int firstIndex, int secondIndex, List<Box<T>> list)
        {
            Box<T> elemt = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = elemt;
        }
    }
}
