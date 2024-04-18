namespace _4.List_of_Products
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> products = new List<string>(n);
            products = ReadProducts(n, products);

            products.Sort();
            PrintProducts(n, products);
        }

        static void PrintProducts(int count, List<string> products)
        {

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i+1}.{products[i]}");
            }
        }

        static List<string> ReadProducts(int count, List<string> products) 
        {
            for (int i = 0; i < count; i++)
            {
                string product = Console.ReadLine();
                products.Add(product);
            }

            return products;
        }
    }
}