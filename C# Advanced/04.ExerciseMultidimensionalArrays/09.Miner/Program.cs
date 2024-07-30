namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] matrix = new char[fieldSize, fieldSize];

            string[] inputCommandsMove = Console.ReadLine().Split();

            int countOfCoal = 0;
            int minerRowCoordinates = 0;
            int minerColCoordinates = 0;
            for (int row = 0; row < fieldSize; row++)
            {
                string inputRow = Console.ReadLine().Replace(" ", "");
                for (int col = 0; col < fieldSize; col++)
                {
                    matrix[row, col] = inputRow[col];
                    if (inputRow[col] == 'c')
                    {
                        countOfCoal++;
                    }

                    if (inputRow[col] == 's')
                    {
                        minerRowCoordinates = row;
                        minerColCoordinates = col;
                    }
                }
            }

            int currentRow = minerRowCoordinates;
            int currentCol = minerColCoordinates;

            int collectedCoal = 0;
            bool isGameOver = false;
            for (int direction = 0; direction < inputCommandsMove.Length; direction++)
            {
                string command = inputCommandsMove[direction];

                if (command == "left" && currentCol - 1 >= 0)
                {
                    currentCol--;

                    if (matrix[currentRow, currentCol] == 'c')
                    {
                        collectedCoal++;
                        matrix[currentRow, currentCol] = '*';
                    }

                    if (matrix[currentRow, currentCol] == 'e')
                    {
                        isGameOver = true;
                        break;
                    }
                }
                else if (command == "right" && currentCol + 1 < fieldSize)
                {
                    currentCol++;

                    if (matrix[currentRow, currentCol] == 'c')
                    {
                        collectedCoal++;
                        matrix[currentRow, currentCol] = '*';
                    }

                    if (matrix[currentRow, currentCol] == 'e')
                    {
                        isGameOver = true;
                        break;
                    }
                }
                else if (command == "up" && currentRow - 1 >= 0)
                {
                    currentRow--;
                    if (matrix[currentRow, currentCol] == 'c')
                    {
                        collectedCoal++;
                        matrix[currentRow, currentCol] = '*';
                    }

                    if (matrix[currentRow, currentCol] == 'e')
                    {
                        isGameOver = true;
                        break;
                    }
                }
                else if (command == "down" && currentRow + 1 < fieldSize)
                {
                    currentRow++;

                    if (matrix[currentRow, currentCol] == 'c')
                    {
                        collectedCoal++;
                        matrix[currentRow, currentCol] = '*';
                    }

                    if (matrix[currentRow, currentCol] == 'e')
                    {
                        isGameOver = true;
                        break;
                    }
                }

                if (collectedCoal == countOfCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                    break;
                }
            }

            if (isGameOver)
            {
                Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
            }

            if (isGameOver == false && collectedCoal != countOfCoal)
            {
                Console
                .WriteLine
                ($"{countOfCoal - collectedCoal} coals left. ({currentRow}, {currentCol})");
            }
        }
    }
}
