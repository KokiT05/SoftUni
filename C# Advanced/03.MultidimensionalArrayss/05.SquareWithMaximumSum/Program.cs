namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int n = 2;
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

            for (int row = 0; row < matrix.GetLength(0) - n + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - n + 1; col++)
                {

                    for (int insideRow = 1; insideRow < n; insideRow++)
                    {
                        for (int insideCol = 1; insideCol < n; insideCol++)
                        {
                            sumOfSquear = matrix[row, col] +
                                            matrix[row, col + insideCol] +
                                            matrix[row + insideRow, col] +
                                            matrix[row + insideRow, col + insideCol];

                            if (maxValueSuqearSum < sumOfSquear)
                            {
                                rowIndex = row;
                                colIndex = col;
                                maxValueSuqearSum = sumOfSquear;
                            }
                        }
                    }
                }
            }

            for (int row = rowIndex; row < rowIndex + n; row++)
            {
                for (int col = colIndex; col < colIndex + n; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxValueSuqearSum);
        }
    }
}
