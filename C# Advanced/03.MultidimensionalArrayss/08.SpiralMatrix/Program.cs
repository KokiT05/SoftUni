namespace _08.SpiralMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            string direction = "right";


            int row = 0;
            int col = 0;
            for (int i = 1; i <= n * n; i++)
            {
                matrix[row, col] = i;

                Direction(ref row, ref col, direction);
                SpiralMatrixOperation(ref row, ref col, ref direction, matrix);
            }

            PrintMatrix(matrix);
        }

        static void Direction(ref int row, ref int col, string direction)
        {
            if (direction == "right")
            {
                col++;
            }
            else if (direction == "down")
            {
                row++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "up")
            {
                row--;
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int rowMatrix = 0; rowMatrix < matrix.GetLength(0); rowMatrix++)
            {
                for (int colMatrix = 0; colMatrix < matrix.GetLength(1); colMatrix++)
                {
                    if (matrix[rowMatrix, colMatrix] < 10)
                    {
                        Console.Write($" {matrix[rowMatrix, colMatrix]} ");
                    }
                    else
                    {
                        Console.Write($"{matrix[rowMatrix, colMatrix]} ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void SpiralMatrixOperation
        (ref int row, 
        ref int col, 
        ref string direction, 
        int[,] matrix)
        {
            if (direction == "right" && (col >= matrix.GetLength(0) || matrix[row, col] != 0))
            {
                col--;
                row++;
                direction = "down";
            }
            else if (direction == "down" && (row >= matrix.GetLength(0) || matrix[row, col] != 0))
            {
                row--;
                col--;
                direction = "left";
            }
            else if (direction == "left" && (col < 0 || matrix[row, col] != 0))
            {
                col++;
                row--;
                direction = "up";
            }
            else if (direction == "up" && (row < 0 || matrix[row, col] != 0))
            {
                row++;
                col++;
                direction = "right";
            }
        }
    }
}
