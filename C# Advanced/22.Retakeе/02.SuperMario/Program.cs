namespace _02.SuperMario
{
    public class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int sizeOfCastle = int.Parse(Console.ReadLine());

            char[][] castleMaze = new char[sizeOfCastle][];
            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < sizeOfCastle; row++)
            {
                string inputRow = Console.ReadLine();
                castleMaze[row] = new char[inputRow.Length];
                for (int col = 0; col < inputRow.Length; col++)
                {
                    castleMaze[row][col] = inputRow[col];
                    if (castleMaze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                string inputCommand = Console.ReadLine();
                string[] command = inputCommand.Split();
                string direction = command[0];
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                if (InMaze(row, col, castleMaze))
                {
                    castleMaze[row][col] = 'B';
                }

                castleMaze[marioRow][marioCol] = '-';

                if (direction == "W" && InMaze(marioRow - 1, marioCol, castleMaze))
                {
                    marioRow--;
                }
                else if (direction == "S" && InMaze(marioRow + 1, marioCol, castleMaze))
                {
                    marioRow++;
                }
                else if (direction == "A" && InMaze(marioRow, marioCol - 1, castleMaze))
                {
                    marioCol--;
                }
                else if (direction == "D" && InMaze(marioRow, marioCol + 1, castleMaze))
                {
                    marioCol++;
                }

                lives -= 1;

                if (castleMaze[marioRow][marioCol] == 'P')
                {
                    castleMaze[marioRow][marioCol] = '-';
                    Console.
                        WriteLine($"Mario has successfully saved " +
                        $"the princess! Lives left: {lives}");
                    PrintCastle(sizeOfCastle, castleMaze);
                    return;
                }

                if (castleMaze[marioRow][marioCol] == 'B')
                {
                    lives -= 2;
                }

                castleMaze[marioRow][marioCol] = 'M';

                if (lives <= 0)
                {
                    break;
                }
            }

            castleMaze[marioRow][marioCol] = 'X';
            Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            PrintCastle(sizeOfCastle, castleMaze);
        }
        public static bool InMaze(int row, int col, char[][] castleMaze)
        {
            if ((row >= 0 && row < castleMaze.Length) &&
                (col >= 0 && col < castleMaze[row].Length))
            {
                return true;
            }

            return false;
        }

        public static void PrintCastle(int sizeCastle, char[][] castleMaze)
        {
            for (int row = 0; row < castleMaze.Length; row++)
            {
                //string inputRow = Console.ReadLine();
                for (int col = 0; col < castleMaze[row].Length; col++)
                {
                    Console.Write(castleMaze[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
