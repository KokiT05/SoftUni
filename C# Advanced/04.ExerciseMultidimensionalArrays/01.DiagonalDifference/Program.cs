namespace _01.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int row = 0; row < n; row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }

            int sumOfPrimaryDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumOfPrimaryDiagonal += matrix[i,i];
            }

            int sumOfSecondaryDiagonal = 0;
            int count = 0;
            for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
            {
                sumOfSecondaryDiagonal += matrix[count,i];
                count++;
            }

            Console.WriteLine(Math.Abs(sumOfPrimaryDiagonal - sumOfSecondaryDiagonal));
        }
    }
}