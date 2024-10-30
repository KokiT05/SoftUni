using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Ingredient: {this.Name}{Environment.NewLine}" +
                $"Quantity: {this.Quantity}{Environment.NewLine}" +
                $"Alcohol: {this.Alcohol}";
        }
    }
}
