namespace _02.GenericArrayCreator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "AAAAAA");
            int[] ints = ArrayCreator.Create(6, 456);

            foreach (int i in ints)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            foreach (string item in strings)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
