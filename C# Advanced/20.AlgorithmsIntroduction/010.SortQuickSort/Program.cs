﻿namespace _010.SortQuickSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 14, 5, 41, 3, 23 };
            Console.WriteLine("Before QuickSort: ");
            Console.WriteLine(string.Join(", ", array));

            Sort(array, 0, array.Length - 1);

            Console.WriteLine("After QuickSort");
            Console.WriteLine(string.Join(", ", array));
            //Console.WriteLine("Hello, World!");
        }

        public static void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                Sort(array, left, pivotIndex - 1);
                Sort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int a, int b)
        {
            //if (a != b)
            //{
            //    array[a] = array[a] ^ array[b];
            //    array[b] = array[a] ^ array[b];
            //    array[a] = array[a] ^ array[b];
            //}

            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
