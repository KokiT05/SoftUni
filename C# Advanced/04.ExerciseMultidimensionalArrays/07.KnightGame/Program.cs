namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardSide = int.Parse(Console.ReadLine());

            string[,] board = new string[boardSide, boardSide];

            // Filling the board
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = currentRow[col].ToString();
                }
            }

            int knightsInDangerCounter = 0; // Counting how many knights can be attacked from current knight.
            int removedKnightsCounter = 0; // Counting removed knights from the board.

            for (int maxAttackPotential = 8; maxAttackPotential > 0; maxAttackPotential--) // Every knight can attack and kill maximum 8 other knights. P.S. Check "Possible moves" at the beginning.
            {
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        if (board[row, col].ToLower() == "k") // Check if we have knight on current position.
                        {
                            // Check if new position isn't outside of the board (so we don't get IndexOutOfRangeException).
                            if (row - 1 >= 0)
                            {
                                if (col - 2 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition.
                                    if (board[row - 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < board.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition.
                                    if (board[row - 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 1 < board.GetLength(0))
                            {
                                if (col - 2 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (board[row + 1, col - 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 2 < board.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (board[row + 1, col + 2].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row - 2 >= 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (board[row - 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (board[row - 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }

                            if (row + 2 < board.GetLength(0))
                            {
                                if (col - 1 >= 0)
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (board[row + 2, col - 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }

                                if (col + 1 < board.GetLength(1))
                                {
                                    // Check if there is knight to be attacked on the new possition
                                    if (board[row + 2, col + 1].ToLower() == "k")
                                    {
                                        knightsInDangerCounter++;
                                    }
                                }
                            }
                        }

                        // Check if every possible attack is against another knight (attack potential of current knight is biggest possible)
                        if (knightsInDangerCounter == maxAttackPotential)
                        {
                            board[row, col] = "0"; // Remove knight from board.
                            removedKnightsCounter++;
                        }

                        knightsInDangerCounter = 0; // Restart counter.
                    }
                }
            }

            // Print result
            Console.WriteLine(removedKnightsCounter);

            //int n = int.Parse(Console.ReadLine());

            //char[,] matrix = new char[n, n];

            //Dictionary<string, int> knightsAttack = new Dictionary<string, int>();
            //int countOfKnight = 0;

            //for (int row = 0; row < n; row++)
            //{
            //    string inputRowData = Console.ReadLine();

            //    for (int col = 0; col < n; col++)
            //    {
            //        matrix[row, col] = inputRowData[col];
            //        if (inputRowData[col] == 'K')
            //        {
            //            countOfKnight++;
            //            knightsAttack.Add($"{row}{col}", 0);
            //        }
            //    }
            //}

            //int knightAttackMax = int.MaxValue;
            //int countOfIteration = 0;
            //while (knightAttackMax > 0)
            //{
            //    for (int row = 0; row < n; row++)
            //    {
            //        for (int col = 0; col < n; col++)
            //        {
            //            if (matrix[row, col] == 'K' && knightsAttack.ContainsKey($"{row}{col}"))
            //            {
            //                if ((row + 1 < n && col + 2 < n) &&
            //                    matrix[row + 1, col + 2] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }

            //                if ((row - 1 >= 0 && col + 2 < n) &&
            //                    matrix[row - 1, col + 2] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }

            //                if (
            //                    (row + 2 < n && col + 1 < n) &&
            //                    matrix[row + 2, col + 1] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }

            //                if ((row + 2 < n && col - 1 >= 0) &&
            //                    matrix[row + 2, col - 1] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }

            //                if (
            //                    (row + 1 < n && col - 2 >= 0) &&
            //                    matrix[row + 1, col - 2] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }

            //                if ((row - 1 >= 0 && col - 2 >= 0) &&
            //                    matrix[row - 1, col - 2] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }

            //                if ((row - 2 >= 0 && col + 1 < n) &&
            //                    matrix[row - 2, col + 1] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }


            //                if ((row - 2 >= 0 && col - 1 >= 0) &&
            //                    matrix[row - 2, col - 1] == 'K')
            //                {
            //                    knightsAttack[$"{row}{col}"]++;
            //                }
            //            }
            //        }
            //    }

            //    if (knightsAttack.Count > 0)
            //    {
            //        knightAttackMax = knightsAttack.Max(v => v.Value);
            //    }
            //    if (knightAttackMax > 0 && knightsAttack.Count > 0)
            //    {
            //        string coordinates = knightsAttack.First(v => (v.Value == knightAttackMax)).Key;
            //        int rowCoordinates = int.Parse(coordinates[0].ToString());
            //        int colCoordinates = int.Parse(coordinates[1].ToString());
            //        matrix[rowCoordinates, colCoordinates] = '0';
            //        knightsAttack.Remove(coordinates);

            //        foreach (string coordinatesKey in knightsAttack.Keys)
            //        {
            //            knightsAttack[coordinatesKey] = 0;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //    countOfIteration++;
            //}


            //Console.WriteLine(countOfIteration);


            //knightsAttack = knightsAttack
            //    .OrderByDescending(v => v.Value)
            //    .ToDictionary(k => k.Key, v => v.Value);
        }
    }
}
