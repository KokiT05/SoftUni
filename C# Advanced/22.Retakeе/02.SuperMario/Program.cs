namespace _02.SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int numberOfRows = int.Parse(Console.ReadLine());

            char[,] castleMaze = new char[numberOfRows, numberOfRows];

            for (int row = 0; row < numberOfRows; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < inputRow.Length; col++)
                {
                    castleMaze[row, col] = inputRow[col];
                }
            }

            for (int row = 0; row < castleMaze.GetLength(0); row++)
            {
                //string inputRow = Console.ReadLine();
                for (int col = 0; col < castleMaze.GetLength(1); col++)
                {
                    Console.Write(castleMaze[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
