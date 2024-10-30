using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailParty
{
    public class Cocktail
    {
        //private Dictionary<string, Ingredient> Ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new Dictionary<string, Ingredient>(this.Capacity);
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public Dictionary<string, Ingredient> Ingredients { get; set; }

        public int CurrentAlcoholLevel { get { return this.Ingredients.Values.Sum(i => i.Alcohol); } }
        public void Add(Ingredient ingredient)
        {
            if (this.Ingredients.ContainsKey(ingredient.Name) ||
                this.Ingredients.Count >= this.Capacity - 1 ||
                this.Ingredients.Sum(i => i.Value.Alcohol) >= this.MaxAlcoholLevel)
            {
                return;
            }

            this.Ingredients.Add(ingredient.Name ,ingredient);
        }

        public bool Remove(string name)
        {
            if (this.Ingredients.ContainsKey(name))
            {
                this.Ingredients.Remove(name);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (this.Ingredients.ContainsKey(name))
            {
                return this.Ingredients[name];
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.Ingredients.
                        First(i => i.Value.Alcohol == this.Ingredients.Max(i => i.Value.Alcohol)).Value;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.
            AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (Ingredient ingredient in this.Ingredients.Values)
            {
                stringBuilder.AppendLine(ingredient.ToString());
            }

            return stringBuilder.ToString().Trim();
        } 
    }
}
