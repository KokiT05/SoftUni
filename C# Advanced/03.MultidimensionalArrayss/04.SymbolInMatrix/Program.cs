namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col].ToString();
                }
            }

            string symbol = Console.ReadLine();
            bool isFind = false;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (symbol == matrix[row, col].ToString())
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFind = true;
                        break;
                    }
                }

                if (isFind)
                {
                    break;
                }
            }

            if (!isFind)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
