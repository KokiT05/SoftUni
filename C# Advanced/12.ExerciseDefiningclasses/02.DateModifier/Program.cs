namespace _02.DateModifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            DateModifier dateModifier = new DateModifier();
            Console.WriteLine(dateModifier.GetDaysBetween(firstDate, secondDate));
        }
    }
}
