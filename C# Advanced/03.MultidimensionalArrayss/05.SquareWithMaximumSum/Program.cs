namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rowMatrix = matrixData[0];
            int colMatrix = matrixData[1];
            int[,] matrix = new int[rowMatrix, colMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++) 
            {
                int[] inputData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }

            int maxValueSuqearSum = int.MinValue;
            int sumOfSquear = 0;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    sumOfSquear = matrix[row, col] + 
                                matrix[row, col + 1] + 
                                matrix[row + 1, col] +
                                matrix[row + 1, col + 1];

                    if (maxValueSuqearSum < sumOfSquear)
                    {
                        rowIndex = row;
                        colIndex = col;
                        maxValueSuqearSum = sumOfSquear;
                    }
                }
            }

            for (int row = rowIndex; row < rowIndex + 2; row++)
            {
                for (int col = colIndex; col < colIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxValueSuqearSum);
        }
    }
}
