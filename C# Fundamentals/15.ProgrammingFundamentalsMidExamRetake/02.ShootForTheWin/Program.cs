namespace _02.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] shotTargets = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

            Console.WriteLine(string.Join(' ', shotTargets));
        }
    }
}