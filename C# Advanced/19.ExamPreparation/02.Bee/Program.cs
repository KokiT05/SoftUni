namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTerritory = int.Parse(Console.ReadLine());
            char[,] territory = new char[sizeOfTerritory, sizeOfTerritory];

            int beeRow = 0;
            int beeCol = 0;
            int polinatedFlower = 0;

            for (int i = 0; i < sizeOfTerritory; i++)
            {
                string inputRow = Console.ReadLine();
                for (int j = 0; j < inputRow.Length; j++)
                {
                    if (inputRow[j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                    territory[i,j] = inputRow[j];
                }
            }
            bool isLost = false;
            string command = Console.ReadLine();
            while (command != "End")
            {
                territory[beeRow, beeCol] = '.';
                beeRow = MoveBeeRow(beeRow, command);
                beeCol = MoveBeeCol(beeCol, command);

                isLost = (beeRow == sizeOfTerritory || beeRow < 0) ||
                         (beeCol == sizeOfTerritory || beeCol < 0);
                if (isLost)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (territory[beeRow, beeCol] == 'f')
                {
                    territory[beeRow, beeCol] = 'B';
                    polinatedFlower++;
                }
                else if (territory[beeRow, beeCol] == 'O')
                {
                    continue;
                }

                territory[beeRow, beeCol] = 'B';

                command = Console.ReadLine();
            }

            int needPolinatedFlower = 5;
            if (polinatedFlower >= needPolinatedFlower)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {polinatedFlower} flowers!");
            }
            else
            {
                Console
                .WriteLine
                ($"The bee couldn't pollinate the flowers, she needed {needPolinatedFlower - polinatedFlower} flowers more");
            }

            PrintTerritory(sizeOfTerritory, territory);
        }

        static void PrintTerritory(int sizeOfTerritory, char[,] territory)
        {
            for (int i = 0; i < sizeOfTerritory; i++)
            {
                for (int j = 0; j < sizeOfTerritory; j++)
                {
                    Console.Write($"{territory[i, j]}");
                }
                Console.WriteLine();
            }
        }

        static int MoveBeeRow(int beeRow, string command)
        {
            if (command == "up")
            {
                beeRow--;
            }
            else if (command == "down")
            {
                beeRow++;
            }

            return beeRow;
        }

        static int MoveBeeCol(int beeCol, string command)
        {
            if (command == "right")
            {
                beeCol++;
            }
            else if (command == "left")
            {
                beeCol--;
            }

            return beeCol;
        }
    }
}
