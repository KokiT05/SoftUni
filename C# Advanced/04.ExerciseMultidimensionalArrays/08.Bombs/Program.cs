namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] rowsData = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowsData[col];
                }
            }

            int[] bombsCoordinates = Console.ReadLine()
                                    .Split(new char[] {' ', ',' }, 
                                    StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            int bombDamage = 0;
            for (int cout = 0; cout < bombsCoordinates.Length - 1; cout = cout + 2)
            {
                int row = bombsCoordinates[cout];
                int col = bombsCoordinates[cout + 1];
                bombDamage = matrix[row, col];

                if (bombDamage > 0)
                {
                    matrix[row, col] = 0;
                    if (row - 1 >= 0)
                    {
                        if (IsNotNull(matrix, row - 1, col) && 
                            IsNotDead(matrix, row - 1, col))
                        {
                            matrix[row - 1, col] -= bombDamage;
                        }

                        if (col + 1 < n &&
                            IsNotNull(matrix, row - 1, col + 1) &&
                            IsNotDead(matrix, row - 1, col + 1))
                        {
                            matrix[row - 1, col + 1] -= bombDamage;
                        }

                        if (col - 1 >= 0 &&
                            IsNotNull(matrix, row - 1, col - 1) &&
                            IsNotDead(matrix, row - 1, col - 1))
                        {
                            matrix[row - 1, col - 1] -= bombDamage;
                        }
                    }


                    if (col + 1 < n && 
                        IsNotNull(matrix, row, col + 1) &&
                        IsNotDead(matrix, row, col + 1))
                    {
                        matrix[row, col + 1] -= bombDamage;
                    }

                    if (row + 1 < n && 
                        col + 1 < n && 
                        IsNotNull(matrix, row + 1, col + 1) &&
                        IsNotDead(matrix, row + 1, col + 1))
                    {
                        matrix[row + 1, col + 1] -= bombDamage;
                    }

                    if (row + 1 < n && 
                        IsNotNull(matrix, row + 1, col) &&
                        IsNotDead(matrix, row + 1, col))
                    {
                        matrix[row + 1, col] -= bombDamage;
                    }

                    if (row + 1 < n && 
                        col - 1 >= 0 && 
                        IsNotNull(matrix, row + 1, col - 1) &&
                        IsNotDead(matrix, row + 1, col - 1))
                    {
                        matrix[row + 1, col - 1] -= bombDamage;
                    }

                    if (col - 1 >= 0 && 
                        IsNotNull(matrix, row, col - 1) &&
                        IsNotDead(matrix, row, col - 1))
                    {
                        matrix[row, col - 1] -= bombDamage;
                    }
                }
            }

            PrintOutput(matrix);
        }

        static bool IsNotNull(int[,] matrix, int row, int col)
        {
            if (matrix[row, col] == 0)
            {
                return false;
            }

            return true;
        }

        static bool IsNotDead(int[,] matrix, int row, int col)
        {
            if (matrix[row, col] > 0)
            {
                return true;
            }

            return false;
        }

        static void PrintOutput(int[,] matrix)
        {
            int aliveCellSum = 0;
            int countOfAliveCell = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellSum += matrix[row, col];
                        countOfAliveCell++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countOfAliveCell}");
            Console.WriteLine($"Sum: {aliveCellSum}");

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
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
