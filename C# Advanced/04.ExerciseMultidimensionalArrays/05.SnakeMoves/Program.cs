using System;
using System.Reflection;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int rowSize = inputData[0];
            int columnSize = inputData[1];
            string[,] matrix = new string[rowSize, columnSize];

            string snace = Console.ReadLine();

            int index = 0;
            int matrixRow = 0;
            int matrixCol = 0;
            string direction = "left";

            while (matrixRow < rowSize)
            {

                if (direction == "left")
                {
                    index = LeftOperationMatrix(matrix, index, snace, matrixRow);

                    direction = "right";
                }
                else if (direction == "right")
                {
                    index = RightOperationMatrix(matrix, index, snace, matrixRow);

                    direction = "left";
                }

                matrixRow++;
            }

            PrintMatrix(matrix);
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        static int LeftOperationMatrix
                (string[,] matrix, 
                int index, 
                string snace, 
                int matrixRow)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (index == snace.Length)
                {
                    index = 0;
                }

                matrix[matrixRow, col] = snace[index].ToString();
                index++;
            }

            return index;
        }

        static int RightOperationMatrix
                (string[,] matrix,
                int index,
                string snace,
                int matrixRow)
        {
            for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
            {
                if (index == snace.Length)
                {
                    index = 0;
                }

                matrix[matrixRow, col] = snace[index].ToString();
                index++;
            }
            return index;
        }
    }
}
