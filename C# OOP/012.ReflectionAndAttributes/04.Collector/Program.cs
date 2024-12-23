namespace _04.Collector // Stealer
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("_04.Collector.Hacker");
            Console.WriteLine(result);
        }
    }
}
