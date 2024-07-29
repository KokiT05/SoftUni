namespace _03.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int rowSize = matrixData[0];
            int colSize = matrixData[1];

            int[,] matrix = new int[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputRow = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int maxSquareSum = int.MinValue;
            int sumOfSquare = 0;
            int rowIndex = 0;
            int columnIndex = 0;
            int n = 3;

            for (int row = 0; row < (matrix.GetLength(0) - n) + 1; row++)
            {
                for (int col = 0; col < (matrix.GetLength(1) - n) + 1; col++)
                {

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            sumOfSquare += matrix[row + i, col + j];
                        }
                    }

                    if (sumOfSquare > maxSquareSum)
                    {
                        maxSquareSum = sumOfSquare;
                        rowIndex = row;
                        columnIndex = col;
                    }
                    sumOfSquare = 0;

                }
            }

            Console.WriteLine($"Sum = {maxSquareSum}");
            for (int row = rowIndex; row < rowIndex + n; row++)
            {
                for (int col = columnIndex; col < columnIndex + n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
