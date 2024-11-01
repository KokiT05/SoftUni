namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            Console.WriteLine(randomList.RandomString());
            randomList.Add("1");
            randomList.Add("2");
            randomList.Add("3");
            randomList.Add("4");
            randomList.Add("5");

            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine();
            foreach (string item in randomList)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
