namespace _02.EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    ReadNumber(1, 10);
                }
            }
            catch (Exception exception) 
            when (exception is IndexOutOfRangeException || exception is FormatException)
            {
                Console.WriteLine(exception.Message);
                for (int i = 1; i <= 10 ; i++)
                {
                    ReadNumber(1, 20);
                }
            }
        }

        public static void ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < start || number > end)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
