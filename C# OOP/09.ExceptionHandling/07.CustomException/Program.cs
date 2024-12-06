namespace _07.CustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Ivan", "ivancho04@abv.bg");
                Student studentTwo = new Student("Ivanch@", "ivancho04@abv.bg");
            }
            catch (InvalidPersonNameException personNameException)
            {
                Console.WriteLine($"Exception: {personNameException.Message}");
            }
        }
    }
}
