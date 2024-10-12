namespace _03.GenericScale
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equalityScale = new EqualityScale<int>(23, 243);
            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}
