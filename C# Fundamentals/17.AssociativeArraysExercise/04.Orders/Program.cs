namespace _04.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> productPrice = new Dictionary<string, double>();
            Dictionary<string, int> productQuantity = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "buy")
            {
                string[] cmdArg = input.Split(' ');
                string product = cmdArg[0];
                double price = double.Parse(cmdArg[1]);
                int quantity = int.Parse(cmdArg[2]);

                if (productPrice.ContainsKey(product) == false && 
                    productQuantity.ContainsKey(product) == false)
                {
                    productPrice.Add(product, price);
                    productQuantity.Add(product, quantity);
                }
                else if (productPrice.ContainsKey(product) && productQuantity.ContainsKey(product))
                {
                    productPrice[product] = price;
                    productQuantity[product] = productQuantity[product] + quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var item in productPrice)
            {
                Console.WriteLine($"{item.Key} -> {(productQuantity[item.Key] * item.Value):f2}");
            }
        }
    }
}