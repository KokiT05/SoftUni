using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace _02.Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] coordinates = Console.ReadLine()  
                                .Split(new char[] {',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

            char[,] field = new char[fieldSize, fieldSize];

            //Dictionary<char, List<string>> playerCoordinates = new Dictionary<char, List<string>>();
            //playerCoordinates.Add('<', new List<string>());
            //playerCoordinates.Add('>', new List<string>());

            int shipsCountFirstPlayer = 0;
            int shipsCountSecondPlayer = 0;
            int destroyedShips = 0;

            for (int row = 0; row < fieldSize; row++)
            {
                char[] inputCharacter = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
                for (int col = 0; col < fieldSize; col++)
                {
                    if (inputCharacter[col] == '<')
                    {
                        shipsCountFirstPlayer++;
                    }
                    else if (inputCharacter[col] == '>')
                    {
                        shipsCountSecondPlayer++;
                    }

                    field[row, col] = inputCharacter[col];
                }
            }

            int counterTurn = 1;
            for (int i = 0; i < coordinates.Length; i = i + 2)
            {
                int row = coordinates[i];
                int col = coordinates[i + 1];

                if (!InField(row, col, fieldSize))
                {
                    counterTurn++;
                    continue;
                }

                if (counterTurn % 2 == 0 && field[row, col] == '<')
                {
                    destroyedShips++;
                    shipsCountFirstPlayer--;
                    field[row, col] = '*';
                }
                else if (field[row, col] == '>')
                {
                    destroyedShips++;
                    shipsCountSecondPlayer--;
                    field[row, col] = '*';
                }


                if (field[row, col] == '#')
                {
                    for (int rowMine = row - 1; rowMine <= row + 1; rowMine++)
                    {
                        for (int colMine = col - 1; colMine <= col + 1; colMine++)
                        {
                            if (InField(rowMine, colMine, fieldSize))
                            {
                                char currentPosition = field[rowMine, colMine];
                                if (currentPosition == '>')
                                {
                                    destroyedShips++;
                                    shipsCountSecondPlayer--;
                                    field[row, col] = '*';
                                }
                                else if (currentPosition == '<')
                                {
                                    destroyedShips++;
                                    shipsCountFirstPlayer--;
                                    field[row, col] = '*';
                                }
                            }
                        }
                    }
                }

                if (shipsCountFirstPlayer == 0)
                {
                    Console.WriteLine($"Player Two has won the game! " +
                            $"{destroyedShips} ships have been sunk in the battle.");
                    return;
                }
                else if (shipsCountSecondPlayer == 0)
                {
                    Console.WriteLine($"Player One has won the game! " +
                        $"{destroyedShips} ships have been sunk in the battle.");
                    return;
                }

                counterTurn++;
            }

            Console.WriteLine($"It's a draw! Player One has " +
                            $"{shipsCountFirstPlayer} ships left. Player Two has " +
                            $"{shipsCountSecondPlayer} ships left.");


            //for (int row = 0; row < field.GetLength(0); row++)
            //{
            //    for (int col = 0; col < field.GetLength(1); col++)
            //    {
            //        Console.Write($"{field[row, col]}");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine($"First player ships: {playerCoordinates['<'].Count}");
            //Console.WriteLine($"First player ships: {playerCoordinates['>'].Count}");
        }

        public static bool InField(int row, int col, int fieldSize)
        {
            if (row >= fieldSize || row < 0 || col >= fieldSize || col < 0)
            {
                return false;
            }
            return true;
        }

    }
}
