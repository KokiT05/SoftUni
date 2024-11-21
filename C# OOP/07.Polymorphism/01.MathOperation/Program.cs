namespace _01.MathOperation // Operations
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            MathOperations mathOperations = new MathOperations();
            Console.WriteLine(mathOperations.Add(2, 3));
            Console.WriteLine(mathOperations.Add(2.2, 3.3, 5.5));
            Console.WriteLine(mathOperations.Add(2.2M, 3.3M, 4.4M));
        }
    }
}
