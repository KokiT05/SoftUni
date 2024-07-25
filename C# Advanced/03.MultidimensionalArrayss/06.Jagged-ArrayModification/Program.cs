namespace _06.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] inputData = Console.ReadLine()
                                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                jaggedArray[row] = new int[inputData.Length];

                for (int col = 0; col < inputData.Length; col++)
                {
                    jaggedArray[row][col] = inputData[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArg = command.Split();
                string action = commandArg[0];
                int coordinatesRow = int.Parse(commandArg[1]);
                int coordinatesCol = int.Parse(commandArg[2]);
                int value = int.Parse(commandArg[3]);

                if (action == "Add" && 
                    ISValidCoordinates(coordinatesRow, coordinatesCol, jaggedArray))
                {
                    jaggedArray[coordinatesRow][coordinatesCol] += value;
                }
                else if (action == "Subtract" && 
                    ISValidCoordinates(coordinatesRow, coordinatesCol, jaggedArray))
                {
                    jaggedArray[coordinatesRow][coordinatesCol] -= value;
                }

                command = Console.ReadLine();
            }

            foreach (int[] array in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', array));
            }
        }

        static bool ISValidCoordinates(int row, int col, int[][] jaggedArray)
        {
            if (row < 0 || row >= jaggedArray.Length || col < 0 || col >= jaggedArray[row].Length)
            {
                Console.WriteLine("Invalid coordinates");
                return false;
            }

            return true;
        }
    }
}
