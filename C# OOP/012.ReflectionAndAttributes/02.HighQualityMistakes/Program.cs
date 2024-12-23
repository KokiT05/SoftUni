namespace _02.HighQualityMistakes // Stealer
{
    public class Program // StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.AnalyzeAccessModifiers("_02.HighQualityMistakes.Hacker");
            Console.WriteLine(result);

        }
    }
}
