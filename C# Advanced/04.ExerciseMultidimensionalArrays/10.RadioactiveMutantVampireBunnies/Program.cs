namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            int rowSize = matrixSize[0];
            int colSize = matrixSize[1];

            char[,] matrix = new char[rowSize, colSize];


            int currentRow = 0;
            int currentCol = 0;
            for (int row = 0; row < rowSize; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = inputRow[col];
                    if (inputRow[col] == 'P')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string playerMove = Console.ReadLine();

            bool isWon = false;
            bool isDead = false;
            for (int move = 0; move < playerMove.Length; move++)
            {
                if (playerMove[move] == 'L')
                {
                    matrix[currentRow, currentCol] = '.';
                    if (currentCol - 1 < 0)
                    {
                        isWon = true;
                    }
                    else if (matrix[currentRow, currentCol - 1] == 'B')
                    {
                        currentCol--;
                        isDead = true;
                    }
                    else if (currentCol - 1 >= 0)
                    {
                        currentCol--;
                        matrix[currentRow, currentCol] = 'P';
                    }
                }
                else if (playerMove[move] == 'U')
                {
                    matrix[currentRow, currentCol] = '.';
                    if (currentRow - 1 < 0)
                    {
                        isWon = true;
                    }
                    else if (matrix[currentRow - 1, currentCol] == 'B')
                    {
                        currentRow--;
                        isDead = true;
                    }
                    else if (currentRow - 1 >= 0)
                    {
                        currentRow--;
                        matrix[currentRow, currentCol] = 'P';
                    }
                }
                else if (playerMove[move] == 'R')
                {
                    matrix[currentRow, currentCol] = '.';
                    if (currentCol + 1 >= colSize)
                    {
                        isWon = true;

                    }
                    else if (matrix[currentRow, currentCol + 1] == 'B')
                    {
                        currentCol++;
                        isDead = true;
                    }
                    else if (currentCol + 1 < colSize)
                    {
                        currentCol++;
                        matrix[currentRow, currentCol] = 'P';
                    }
                }
                else if (playerMove[move] == 'D')
                {
                    matrix[currentRow, currentCol] = '.';
                    if (currentRow + 1 >= rowSize)
                    {
                        isWon = true;
                    }
                    else if (matrix[currentRow + 1, currentCol] == 'B')
                    {
                        currentRow++;
                        isDead = true;
                    }
                    else if (currentRow + 1 < rowSize)
                    {
                        currentRow++;
                        matrix[currentRow, currentCol] = 'P';
                    }
                }

                for (int row = 0; row < rowSize; row++)
                {
                    for (int col = 0; col < colSize; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            if (row + 1 < rowSize && matrix[row + 1, col] == 'P')
                            {
                                isDead = true;
                                matrix[row + 1, col] = 'B';
                            }
                            else if (row + 1 < rowSize)
                            {
                                matrix[row + 1, col] = 'B';
                            }
                            
                            if (col - 1 >= 0 && matrix[row, col - 1] == 'P')
                            {
                                isDead = true;
                                matrix[row, col - 1] = 'B';
                            }
                            else if (col - 1 >= 0)
                            {
                                matrix[row, col - 1] = 'B';
                            }
                            
                            if (row - 1 >= 0 && matrix[row - 1, col] == 'P')
                            {
                                isDead = true;
                                matrix[row - 1, col] = 'B';
                            }
                            else if (row - 1 >= 0)
                            {
                                matrix[row - 1, col] = 'B';
                            }
                            
                            if (col + 1 < colSize && matrix[row, col + 1] == 'P')
                            {
                                isDead = true;
                                matrix[row, col + 1] = 'B';
                            }
                            else if (col + 1 < colSize)
                            {
                                matrix[row, col + 1] = 'B';
                            }
                        }
                    }

                    if (isWon)
                    {
                        break;
                    }

                    if (isDead)
                    {
                        break;
                    }
                }
            }


            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < colSize; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }

            if (isWon)
            {
                Console.WriteLine($"won: {currentRow} {currentCol}”");
                return;
            }

            if (isDead)
            {
                Console.WriteLine($"dead: {currentRow} {currentCol}");
            }
        }
    }
}
