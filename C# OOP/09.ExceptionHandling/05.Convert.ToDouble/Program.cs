namespace _05.Convert.ToDouble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                double result = System.Convert.ToDouble(number);
                Console.WriteLine(number);
            }
            catch (FormatException exception)
            {
                Console.WriteLine(exception.Message);
                throw exception;
            }

            //try
            //{
            //    try
            //    {
            //        double result = System.Convert.ToDouble(number);
            //        Console.WriteLine(number);
            //    }
            //    catch (FormatException exception)
            //    {
            //        Console.WriteLine(exception.Message);
            //        throw exception;
            //    }
            //}
            //catch (FormatException exception)
            //{

            //}
        }
    }
}
