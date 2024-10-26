namespace _013.SearchBinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 5, 7, 9, 11, 13 };
            int target = 41;
            int result = BinarySearch(arr, target);

            if (result > 0)
            {
                Console.WriteLine($"Елементът: {target} е на индекс: {result}");
            }
            else
            {
                Console.WriteLine($"Елементът: {target} не е намерен");
            }


            //Console.WriteLine("Hello, World!");
        }

        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (array[mid] == target)
                {
                    return mid;
                }
                else if (array[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }

    }
}
