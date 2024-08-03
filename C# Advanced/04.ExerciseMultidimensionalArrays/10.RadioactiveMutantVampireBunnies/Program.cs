

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rowSize = dimentions[0];
            int colSize = dimentions[1];

            char[,] matrix = new char[rowSize, colSize];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rowSize; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < colSize; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool isWon = false;
            bool isDead = false;

            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                if (direction == 'U')
                {
                    newPlayerRow--;
                }
                else if (direction == 'L')
                {
                    newPlayerCol--;
                }
                else if (direction == 'D')
                {
                    newPlayerRow++;
                }
                else if (direction == 'R')
                {
                    newPlayerCol++;
                }

                if (!IsValidCell(newPlayerRow, newPlayerCol, rowSize, colSize))
                {
                    isWon = true;
                    matrix[playerRow, playerCol] = '.';
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(matrix);
                    SpreadBunnies(bunniesCoordinates, matrix);
                }
                else if (matrix[newPlayerRow, newPlayerCol] == '.')
                {
                    matrix[playerRow, playerCol] = '.';
                    matrix[newPlayerRow, newPlayerCol] = 'P';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(matrix);
                    SpreadBunnies(bunniesCoordinates, matrix);

                    if (matrix[playerRow, playerCol] == 'B')
                    {
                        isDead = true;
                    }
                }
                else if (matrix[newPlayerRow, newPlayerCol] == 'B')
                {
                    isDead = true;
                    matrix[playerRow, playerCol] = '.';
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                    List<int[]> bunniesCoordinates = GetBunniesCoordinates(matrix);
                    SpreadBunnies(bunniesCoordinates, matrix);
                }

                if (isDead || isWon)
                {
                    break;
                }
            }

            PrintField(matrix);
            string result = string.Empty;

            if (isWon)
            {
                result += "won";
            }

            if (isDead)
            {
                result += "dead";
            }

            result += $": {playerRow} {playerCol}";
            Console.WriteLine(result);
        }

        private static void PrintField(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void SpreadBunnies(List<int[]> bunniesCoordinates, char[,] matrix)
        {
            foreach (int[] bunnyCoordinates in bunniesCoordinates)
            {
                int row = bunnyCoordinates[0];
                int col = bunnyCoordinates[1];

                SpreadBunny(row - 1, col, matrix);
                SpreadBunny(row + 1, col, matrix);
                SpreadBunny(row, col - 1, matrix);
                SpreadBunny(row, col + 1, matrix);
            }
        }

        private static void SpreadBunny(int row, int col, char[,] matrix)
        {
            int rowsLenght = matrix.GetLength(0);
            int colsLenght = matrix.GetLength(1);

            if (IsValidCell(row, col, rowsLenght, colsLenght))
            {
                matrix[row, col] = 'B';
            }
        }

        private static List<int[]> GetBunniesCoordinates(char[,] matrix)
        {
            List<int[]> bunniesCoordinates = new List<int[]>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesCoordinates.Add(new int[] { row, col });
                    }
                }
            }

            return bunniesCoordinates;
        }

        private static bool IsValidCell(int row, int col, int rowSize, int colSize)
        {
            return row >= 0 && row < rowSize && col >= 0 && col < colSize;
        }
    }
}
