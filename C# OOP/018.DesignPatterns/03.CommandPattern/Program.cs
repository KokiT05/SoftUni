using _03.CommandPattern.Contracts;

namespace _03.CommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ModifyPrice modifyPrice = new ModifyPrice();
            Product product = new Product("Phone", 500);

            Execute(product, modifyPrice, new ProductCommand(product, Enums.PriceAction.Increase, 100));
            Execute(product, modifyPrice, new ProductCommand(product, Enums.PriceAction.Increase, 50));
            Execute(product, modifyPrice, new ProductCommand(product, Enums.PriceAction.Decrease, 25));

            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
