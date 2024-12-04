namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
                int number = int.Parse(Console.ReadLine());

                if (number < 0)
                {
                    throw new InvalidOperationException();
                }

                double result = Math.Sqrt(number);
                Console.WriteLine(result);
			}
			catch (Exception exception)
			{
                Console.WriteLine("Invalid number");
			}
			finally
			{
                Console.WriteLine("Good bye");
			}
        }
    }
}
