namespace _03.MissionPrivateImpossible //Stealer
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.RevealPrivateMethods($"_03.MissionPrivateImpossible.Hacker");
            Console.WriteLine(result);
        }
    }
}
