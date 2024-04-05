namespace _04.MoreExerciseTribonacciSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long num = long.Parse(Console.ReadLine());
            if (num > 1)
            {
                num = num + 1;
                long[] result = Tribonacci(num);

                for (long i = 1; i < num; i++)
                {
                    Console.Write($"{result[i]} ");
                }
            }
            else
            {
                Console.Write("1");
            }
            //Console.WriteLine(string.Join(" ", result));
        }


        static long[] Tribonacci(long num)
        {
            long[] numbers = new long[num];
            numbers[0] = 0;
            numbers[1] = 1;
            numbers[2] = 1;


            for (long i = 3; i < num; i++)
            {
                numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
            }

            return numbers;
        }
    }
}