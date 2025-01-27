using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CommandPattern
{
    public class Product
    {
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public void IncreasePrice(int amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price for the {this.Name} has been increased by {amount}$");
        }

        public void DecreasePrice(int amount)
        {
            if (amount < this.Price)
            {

                this.Price -= amount;
                Console.WriteLine($"The price for the {this.Name} has been increased by {amount}$");
            }
        }

        public override string ToString()
        {
            return $"Current price for the {this.Name} product is {this.Price}$";
        }
    }
}
