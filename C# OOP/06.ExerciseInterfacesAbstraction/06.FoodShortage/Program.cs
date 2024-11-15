using _05.BirthdayCelebrations;

namespace _06.FoodShortage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();
            IBuyer buyer;

            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string ide = input[2];
                    string birthday = input[3];
                    buyer = new Citizen(name, age, ide, birthday);
                    AddBuyer(name, buyer, buyers);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    buyer = new Rebel(name, age, group);
                    AddBuyer(name, buyer, buyers);
                }
            }

            string buyerName = Console.ReadLine();
            while (buyerName != "End")
            {
                if (IsExistBuyerName(buyerName, buyers))
                {
                    buyers[buyerName].BuyFood();
                }

                buyerName = Console.ReadLine();
            }

            Console.WriteLine(buyers.Values.Sum(f => f.Food));
        }

        public static void AddBuyer(string name, IBuyer buyer, Dictionary<string, IBuyer> buyers)
        {
            if (!IsExistBuyerName(name, buyers))
            {
                buyers.Add(name, buyer);
            }
        }

        public static bool IsExistBuyerName(string name, Dictionary<string, IBuyer> buyers)
        {
            if (buyers.ContainsKey(name))
            {
                return true;
            }

            return false;
        }
    }
}
