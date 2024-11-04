//using AnimalFarm.Models;

namespace _02.AnimalFarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                Chicken chicken = new Chicken(name, age);
                Console
                .WriteLine
                ($"Chicken Maria (age {chicken.Age}) can produce {chicken.ProductPerDay} per day.");
            }
            catch (ArgumentException exceptionMessage)
            {
                Console.WriteLine(exceptionMessage.Message);
            }
        }
    }
}
