namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            int rowSize = inputData[0];
            int columnSize = inputData[1];
            string[,] matrix = new string[rowSize, columnSize];

            string snace = Console.ReadLine();

            int index = 0;
            int matrixRow = 0;
            int matrixCol = 0;

            string direction = "left";

            while (matrixRow < rowSize) 
            {

                if (direction == "left")
                {
                    for (int col = 0; col < columnSize; col++)
                    {
                        if (index == snace.Length)
                        {
                            index = 0;
                        }

                        matrix[matrixRow, col] = snace[index].ToString();
                        index++;
                    }

                    direction = "right";
                }
                else if (direction == "right")
                {
                    for (int col = columnSize - 1; col >= 0; col --)
                    {
                        if (index == snace.Length)
                        {
                            index = 0;
                        }

                        matrix[matrixRow, col] = snace[index].ToString();
                        index++;
                    }

                    direction = "left";
                }

                matrixRow++;
            }

            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < columnSize; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
