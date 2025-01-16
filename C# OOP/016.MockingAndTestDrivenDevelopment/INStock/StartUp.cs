namespace INStock
{
    using INStock.Fake;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            FakeProductStockSystem products = new FakeProductStockSystem();

            products.Add(new FakeProduct("12", 12, 3));

            Console.WriteLine(products.Count);
        }
    }
}
