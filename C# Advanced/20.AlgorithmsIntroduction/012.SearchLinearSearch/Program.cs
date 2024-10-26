namespace _012.SearchLinearSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 94, 41, 51, 3, 8, 12, 17, 25, 33, };
            int target = 7;
            int result = LinearSearch(array, target);

            if (result > 0)
            {
                Console.WriteLine($"Елементът {target} е намерен на индекс {result}");
            }
            else
            {
                Console.WriteLine($"Елементътъ {target} не е намерен");
            }

        }

        public static int LinearSearch(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
