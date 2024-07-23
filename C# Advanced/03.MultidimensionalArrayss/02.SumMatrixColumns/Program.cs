namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowSize = matrixData[0];
            int colSize = matrixData[1];

            int[,] matrix = new int[rowSize, colSize];

            for (int row = 0; row < rowSize; row++)
            {
                int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }

            for (int col = 0; col < colSize; col++)
            {
                int sumOfCol = 0;
                for (int row = 0; row < rowSize; row++)
                {
                    sumOfCol += matrix[row, col];
                }
                Console.WriteLine(sumOfCol);
            }

        }
    }
}
