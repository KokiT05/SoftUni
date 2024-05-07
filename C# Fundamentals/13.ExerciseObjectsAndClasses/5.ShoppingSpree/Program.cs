using System.Security;

namespace _5.ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] personInformatin = Console.ReadLine()
                                            .Split(new char[] {'=', ';'}, 
                                                    StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < personInformatin.Length; i = i + 2)
            {
                string personName = personInformatin[i];
                decimal money = decimal.Parse(personInformatin[+1]);
                Person person = new Person(personName, money);
                people.Add(person);
            }
            string[] productsInformation = Console.ReadLine()
                                                .Split(new char[] {'=', ';'}, 
                                                    StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productsInformation.Length; i = i + 2)
            {
                string productName = productsInformation[i];
                decimal productCost = decimal.Parse(productsInformation[i+1]);
                Product product = new Product(productName, productCost);
                products.Add(product);
            }

            Person currentPerson = new Person(string.Empty, 0M);
            Product currentProduct = new Product(string.Empty, 0M);

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] commandArg = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = commandArg[0];
                string productName = commandArg[1];

                foreach (Person person in people)
                {
                    if (person.Name == personName)
                    {
                        currentPerson = person;
                    }
                }

                foreach (Product product in products)
                {
                    if (product.Name == productName)
                    {
                        currentProduct = product;
                    }
                }

                currentPerson.AddProduct(currentProduct);

                command = Console.ReadLine();
            }

            foreach (Person person in people)
            {
                if (person.products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine
                        ($"{person.Name} - {string.Join(", ", person.products.Select(p => p.Name))}");
                }
            }
        }
    }

    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            products = new List<Product>();
        }
        public string Name { get; set; }

        public decimal Money { get; set; }

        public List<Product> products { get; set; }

        public void AddProduct(Product product) 
        {
            decimal currentMoney = Money - product.Cost;
            if (currentMoney < 0)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} bought {product.Name}");
                products.Add(product);
                Money -= product.Cost;
            }
        }
    }

    public class Product
    {
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }
        public string Name { get; set; }

        public decimal Cost { get; set; }
    }
}