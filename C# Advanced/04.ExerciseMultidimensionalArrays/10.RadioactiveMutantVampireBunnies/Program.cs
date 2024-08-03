
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
                }
            }

        }

        private static bool IsValidCell(int row, int col, int rowSize, int colSize)
        {
            return row >= 0 && row < rowSize && col >= 0 && col < colSize;
        }
    }
}
