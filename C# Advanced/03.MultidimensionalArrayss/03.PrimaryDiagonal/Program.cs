namespace _03.PrimaryDiagonal
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

            int sumOfMatrixPrimaryDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                sumOfMatrixPrimaryDiagonal += matrix[i, i];
            }

            Console.WriteLine(sumOfMatrixPrimaryDiagonal);
        }
    }
}
