namespace _03.GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equalityScale = new EqualityScale<int>(23, 23);
            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}
