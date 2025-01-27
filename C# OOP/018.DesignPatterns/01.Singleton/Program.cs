namespace _01.Singleton
{
    public class Program
    {
        static void Main(string[] args)
        {
            //SingletonDataContainer firstDatabase = SingletonDataContainer.Instance;
            //SingletonDataContainer secondDatabase = SingletonDataContainer.Instance;
            //SingletonDataContainer thirdDatabase = SingletonDataContainer.Instance;
            //SingletonDataContainer fourthDatabase = SingletonDataContainer.Instance;

            SingletonDataContainer database = SingletonDataContainer.Instance;
            Console.WriteLine(database.GetPopulation("Sofiq"));
            SingletonDataContainer secondDatabase = SingletonDataContainer.Instance;
            Console.WriteLine(secondDatabase.GetPopulation("Moscva"));
        }
    }
}
