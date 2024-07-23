namespace _01.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rowSize = matrixData[0];
            int colSize = matrixData[1];

            int[,] matrix = new int[rowSize, colSize];
            int sumOfMatrix = 0;

            for (int row = 0; row < rowSize; row++)
            {
                int[] numbersInput = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = numbersInput[col];
                    sumOfMatrix += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sumOfMatrix);

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write($"{matrix[row, col]} ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
