﻿namespace _09.SortMergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 23, 1, 15, 4 };
            Console.WriteLine($"before mergesort:");
            Console.WriteLine(string.Join(", ", array));
            Sort(array);
            Console.WriteLine($"after mergesort");
            Console.WriteLine(string.Join(", ", array));
        }

        public static void Sort(int[] array)
        {
            if (array.Length <= 1)
                return;

            int mid = array.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            Sort(left);
            Sort(right);

            Merge(array, left, right);
        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

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