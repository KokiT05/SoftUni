namespace _08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] personInformation = Console
                            .ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string fullName = personInformation[0] + " " + personInformation[1];
            string addres = personInformation[2];
            string town = personInformation[3];
            Threeuple<string, string, string> threeupleFirst =
                new Threeuple<string, string, string>(fullName, addres, town);

            string[] beerInformation = Console.
                                        ReadLine().
                                        Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int litersBeer = int.Parse(beerInformation[1]);
            string name = beerInformation[0];
            string isDrunk = beerInformation[1];
            bool flag = true;
            if (isDrunk == "no")
            {
                flag = false;
            }

            Threeuple<string, int, bool> threeupleSecond = 
                new Threeuple<string, int, bool>(name, litersBeer, flag);

            string[] information = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string personName = information[0];
            double doubleNumber = double.Parse(information[1]);
            string bankName = information[2];
            Threeuple<string, double, string> threeupleThird = 
                new Threeuple<string, double, string>(personName, doubleNumber, bankName);

            Console.
            WriteLine
            ($"{threeupleFirst.ItemOne} -> {threeupleFirst.ItemTwo} -> {threeupleFirst.ItemThird}");

            Console.
            WriteLine
            ($"{threeupleSecond.ItemOne} -> {threeupleSecond.ItemTwo} -> {threeupleSecond.ItemThird}");

            Console.
            WriteLine
            ($"{threeupleThird.ItemOne} -> {threeupleThird.ItemTwo} -> {threeupleThird.ItemThird}");
        }
    }
}
