namespace _02.Animals // Animals
{
    internal class Program // StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("123", "321");
            Animal dog = new Dog("222Rex", "Mea13t");


            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
