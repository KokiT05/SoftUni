namespace _011.SortSelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 65, 25, 12, 22, 11 };
            Console.WriteLine($"Before SelectionSort: ");
            Console.WriteLine(string.Join(", ", array));

            Sort(array);
            Console.WriteLine($"After SelectionSort: ");
            Console.WriteLine(string.Join(", ", array));
        }

        public static void Sort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                //if (array[minIndex] != array[i])
                //{
                //    array[minIndex] = array[minIndex] ^ array[i];
                //    array[i] = array[minIndex] ^ array[i];
                //    array[minIndex] = array[minIndex] ^ array[i];
                //}

                int temp = array[minIndex];
                array[minIndex] = array[i];
                array[i] = temp;
            }
        }
    }
}
