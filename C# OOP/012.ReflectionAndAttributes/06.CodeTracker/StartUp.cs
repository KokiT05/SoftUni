namespace _06.CodeTracker // AuthorProblem
{
    [Author("Ivan")]
    public class StartUp // StartUp
    {
        [Author("Koki")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodByAuthor();
        }

        [Author("ILIQN")]
        public static void PrintHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
