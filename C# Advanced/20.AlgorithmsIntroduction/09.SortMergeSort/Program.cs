namespace _09.SortMergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 38, 27, 43, 3, 9, 82, 13 };

            Console.WriteLine($"Before MergeSort:");
            Console.WriteLine(string.Join(", ", array));
            Sort(array);
            Console.WriteLine($"After MergeSort");
            Console.WriteLine(string.Join(", ", array));
        }

        public static void Sort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int mid = array.Length / 2;

            // Създаваме леви и десни подмасиви
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            // Рекурсивно сортиране на подмасивите
            Sort(left);
            Sort(right);

            // Сливане на сортираните подмасиви
            Merge(array, left, right);
        }

        public static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            // Сливане на подмасивите в сортиран ред
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            // Копиране на оставащите елементи, ако има такива
            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
