namespace _4.NumberPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            PrintPyramid(size, number, size);
        }

        public static void PrintPyramid(int n, int number, int space)
        {
            //if (n == 0)
            //    return;

            //// Рекурсивен случай: първо отпечатваме пирамидата за n-1
            //PrintPyramid(n - 1);

            //// След това отпечатваме текущия ред с числото n, повторено n пъти
            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(n + " ");
            //}
            //Console.WriteLine();

            if (n == 0)
            {
                //Console.WriteLine($"{new string(' ', space)}{number}");
                return;
            }

            PrintPyramid(n - 1, number, space);
            Console.Write($"{new string(' ', space - n)}");
            for (int i = 1; i <= n * 2; i++)
            {
                Console.Write($"{number}");
            }

            Console.WriteLine();
        }
    }
}
