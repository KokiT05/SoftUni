namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rows][];

            long currentValue = 0;
            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = new long[row + 1];
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (row - 1 >= 0 && 
                        jaggedArray[row - 1].Length > col && col - 1 >= 0)
                    {
                        currentValue = jaggedArray[row - 1][col];
                        currentValue += jaggedArray[row - 1][col - 1];
                        jaggedArray[row][col] = currentValue;
                    }
                    else
                    {
                        jaggedArray[row][col] = 1;
                    }
                }
            }

            int count = 0;
            foreach (long[] array in jaggedArray)
            {
                Console.WriteLine($"{new string(' ', rows - count)}{string.Join(" ", array)}");
                count++;
            }
        }
    }
}
