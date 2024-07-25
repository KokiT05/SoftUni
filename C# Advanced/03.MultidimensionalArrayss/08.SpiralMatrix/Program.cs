namespace _08.SpiralMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            string direction = "left";


            int row = 0;
            int col = 0;
            for (int i = 1; i <= n * n; i++)
            {
                if (direction == "left")
                {
                    matrix[row, col] = i;
                    col++;
                }
                else if (direction == "down")
                {
                    matrix[row, col] = i;
                    row++;
                }
                else if (direction == "right")
                {
                    matrix[row, col] = i;
                    col--;
                }
                else if (direction == "up")
                {
                    matrix[row, col] = i;
                    row--;
                }

                if (direction == "left" && (col >= n || matrix[row, col] != 0))
                {
                    col--;
                    row++;
                    direction = "down";
                }
                else if (direction == "down" && (row >= n || matrix[row, col] != 0))
                {
                    row--;
                    col--;
                    direction = "right";
                }
                else if (direction == "right" && (col < 0 || matrix[row, col] != 0))
                {
                    col++;
                    row--;
                    direction = "up";
                }
                else if (direction == "up" && (row < 0 || matrix[row, col] != 0))
                {
                    row++;
                    col++;
                    direction = "left";
                }

            }
            Console.WriteLine();

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
    }
}
