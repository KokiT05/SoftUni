namespace _08.SortBubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 9, 3, 14, 41, 123, 2, 8, 5 };
            bool swapped = false;

            Console.WriteLine($"Before Bubble srot");
            Console.WriteLine(string.Join(", ", array));

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }

            Console.WriteLine($"After Bubble sort");
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
