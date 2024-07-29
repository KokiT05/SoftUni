namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] inputRowData = Console.ReadLine()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                jaggedArray[row] = new int[inputRowData.Length];
                for (int col = 0; col < inputRowData.Length; col++)
                {
                    jaggedArray[row][col] = inputRowData[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] = jaggedArray[row][col] * 2;
                        jaggedArray[row + 1][col] = jaggedArray[row + 1][col] * 2;
                    }
                    

                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] = jaggedArray[row][col] / 2;
                    }

                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] = jaggedArray[row + 1][col] / 2;
                    }
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = inputParts[0];
                int row = int.Parse(inputParts[1]);
                int col = int.Parse(inputParts[2]);
                int value = int.Parse(inputParts[3]);

                if (command == "Add")
                {
                    if ((row >= 0 && row < rows) && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] = jaggedArray[row][col] + value;
                    }
                }
                else if (command == "Subtract")
                {
                    if ((row >= 0 && row < rows) && col >= 0 && col < jaggedArray[row].Length)
                    {
                        jaggedArray[row][col] = jaggedArray[row][col] - value;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (int[] array in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', array));
            }
        }
    }
}
