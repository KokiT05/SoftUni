namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfUsername = int.Parse(Console.ReadLine());

            HashSet<string> usernames = new HashSet<string>();
            for (int i = 0; i < countOfUsername; i++)
            {
                string username = Console.ReadLine();

                usernames.Add(username);
            }

            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }    
        }
    }
}
