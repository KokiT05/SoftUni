namespace _02.SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dataMatrix = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowSize = dataMatrix[0];
            int colSize = dataMatrix[1];

            char[,] matrix = new char[rowSize, colSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(char.Parse)
                                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int countOfEqualCharacter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col + 1] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1])
                    {
                        countOfEqualCharacter++;
                    }
                }
            }

            Console.WriteLine(countOfEqualCharacter);
        }
    }
}
