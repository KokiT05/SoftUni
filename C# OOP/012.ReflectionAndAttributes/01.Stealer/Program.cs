namespace _01.Stealer // Stealer
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();

            string result = spy.StealFieldInfo("_01.Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
