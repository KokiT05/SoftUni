namespace _1.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, -9 };
            Console.WriteLine($"Array sum: {array.Sum()}");
            int sumOfArray = ArraySum(array.Length - 1, array);
            Console.WriteLine($"Recursion sum: {sumOfArray}");

        }

        public static int ArraySum(int index, int[] array)
        {
            if (index == 0)
            {
                return array[index];
            }
            //Console.WriteLine(array[index]);
            return array[index] + ArraySum(index - 1, array);
        }
    }
}
