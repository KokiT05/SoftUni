using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> bagProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bagProducts = new List<Product>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyList<Product> BagProducts
        {
            get { return this.bagProducts.AsReadOnly(); }
        }


        public void Bought(Product product)
        {
            this.bagProducts.Add(product);
            this.Money -= product.Cost;
        }

        public string PrintBag()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bagProducts.Count; i++)
            {
                if (i == bagProducts.Count - 1)
                {
                    stringBuilder.Append($"{bagProducts[i].Name}");
                }
                else
                {
                    stringBuilder.Append($"{bagProducts[i].Name}, ");
                }
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
