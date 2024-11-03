using System.Net.Http.Headers;

namespace _03.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] personInput = Console.ReadLine().Split(new char[] { ';', '=' });
            string[] productsInput = Console.ReadLine().Split(new char[] {';', '='});

            Dictionary<string, Person> personBags = new Dictionary<string, Person>();
            Dictionary<string, Product> productCost = new Dictionary<string, Product>();

            try
            {
                Person person;
                for (int i = 0; i < personInput.Length - 1; i = i + 2)
                {
                    string personName = personInput[i];
                    decimal personMoney = decimal.Parse(personInput[i + 1]);
                    person = new Person(personName, personMoney);
                    personBags.Add(personName, person);
                }

                Product product;
                for (int i = 0; i < productsInput.Length - 1; i = i + 2)
                {
                    string productName = productsInput[i];
                    decimal cost = decimal.Parse(productsInput[i + 1]);
                    product = new Product(productName, cost);
                    productCost.Add(productName, product);
                }
            }
            catch (ArgumentException messageException)
            {
                throw new ArgumentException(messageException.Message);
            }

            Person currentPerson;
            Product currentProduct;

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] information = input.Split();
                string personName = information[0];
                string productName = information[1];

                if (!personBags.ContainsKey(personName) || 
                    !productCost.ContainsKey(productName))
                {
                    input = Console.ReadLine();
                    continue;
                }

                currentPerson = personBags[personName];
                currentProduct = productCost[productName];

                if (currentPerson.Money >= currentProduct.Cost)
                {
                    Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    currentPerson.Bought(currentProduct);
                }
                else
                {
                    Console.WriteLine
                        ($"{currentPerson.Name} can't afford {currentProduct.Name}");
                }

                input = Console.ReadLine();
            }

            foreach (Person personBag in personBags.Values)
            {
                if (personBag.BagProducts.Count == 0)
                {
                    Console.WriteLine($"{personBag.Name} - Nothing bought");
                    continue;
                }
                Console.WriteLine($"{personBag.Name} - {personBag.PrintBag()}");
            }
        }
    }
}
