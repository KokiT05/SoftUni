namespace _03.GenericSwapMethodStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> list = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string inputBox = Console.ReadLine();
                Box<string> box = new Box<string>(inputBox);
                list.Add(box);
            }

            int[] indices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstIndex = indices[0];
            int secondIndex = indices[1];

            SpawTwoMethod<string>(firstIndex, secondIndex, list);

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
