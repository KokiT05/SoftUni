namespace _14.ImplementingStackAndQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();

            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);

            Console.WriteLine(customList.Count);
            for (int i = 0; i < customList.Count; i++)
            {
                Console.Write(customList[i] + " ");
            }
            Console.WriteLine();
            customList.Insert(1, 2222);

            Console.WriteLine(customList.Count);
            for (int i = 0; i < customList.Count; i++)
            {
                Console.Write(customList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(customList.Contains(1));
            Console.WriteLine(customList.Contains(1123));

            customList.Swap(0, 4);
            for (int i = 0; i < customList.Count; i++)
            {
                Console.Write(customList[i] + " ");
            }
        }
    }
}
