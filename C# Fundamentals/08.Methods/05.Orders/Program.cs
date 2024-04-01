namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            double quantityOfProduct = double.Parse(Console.ReadLine());
            CalculatePrice(product, quantityOfProduct);
        }

        static void CalculatePrice(string product, double quantity)
        {
            decimal price = 0.0M;
            switch (product)
            {
                case "coffee":
                    price = 1.50M;
                    break;
                case "coke":
                    price = 1.40M;
                    break;
                case "water":
                    price = 1.00M;
                    break;
                case "snacks":
                    price = 2.00M;
                    break;
            }

            double result = Math.Round((quantity * (double)price), 2);
            Console.WriteLine($"{result:f2}");
        }
    }
}