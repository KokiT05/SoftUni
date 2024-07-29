namespace _04.MatrixShuffling
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
            int columnSize = matrixData[1];

            string[,] matrix = new string[rowSize, columnSize];

            for (int row = 0; row < rowSize; row++)
            {
                string[] inputNumbers = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < columnSize; col++)
                {
                    matrix[row, col] = inputNumbers[col];
                }
            }

            string input = Console.ReadLine();
            
            while (input != "END")
            {
                string[] inputParts = input.Split();

                if (inputParts.Length == 5)
                {
                    string command = inputParts[0];
                    int rowOne = int.Parse(inputParts[1]);
                    int colOne = int.Parse(inputParts[2]);
                    int rowTwo = int.Parse(inputParts[3]);
                    int colTwo = int.Parse(inputParts[4]);

                    if (command != "swap" || 
                        ((rowOne < 0 || rowOne > rowSize) ||
                        (colOne < 0 || colOne > columnSize) ||
                        (rowTwo < 0 || rowTwo > rowSize) ||
                        (colTwo < 0 || colTwo > columnSize)))
                    {
                        Console.WriteLine($"Invalid input!");
                    }
                    else
                    {
                        string firstValue = matrix[rowOne, colOne];
                        string secondValue = matrix[rowTwo, colTwo];
                        matrix[rowOne, colOne] = secondValue;
                        matrix[rowTwo, colTwo] = firstValue;

                        PrintMatrix(matrix);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
