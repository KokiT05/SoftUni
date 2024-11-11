using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private double weight;
        private string toppingType;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType
        {
            get
            {
                return this.toppingType;
            }

            private set
            {
                Validator.ThrowIfValueIsNotAllowed
                (new HashSet<string> { "meat", "veggies", "cheese", "sauce" }, 
                value.ToLower(), 
                $"Cannot place {value} on top of your pizza.");

                //if (value != "meat" && 
                //    value != "veggies" && 
                //    value != "cheese" &&
                //    value != "sauce")
                //{
                //    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                //}

                this.toppingType = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }

            private set
            {
                Validator.TrowIfNumberIsNotInRange
                (value,
                MinWeight,
                MaxWeight,
                $"{this.ToppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");

                //if (value < minWeight || value > maxWeight)
                //{
                //    throw new ArgumentException
                //        ($"{this.ToppingType} weight should be in the range [{minWeight}..{maxWeight}].");
                //}
                this.weight = value;
            }
        }

        public double TotalCalories => this.TotalCaloriesMethod();
        private double TotalCaloriesMethod()
        {
            double totalCalories = (2 * this.ToppingCaloriesModifier()) * this.Weight;
            return totalCalories;
        }
        private double ToppingCaloriesModifier()
        {
            if (this.ToppingType.ToLower() == "meat")
            {
                return 1.2;
            }
            else if (this.ToppingType.ToLower() == "veggies")
            {
                return 0.8;
            }
            else if (this.ToppingType.ToLower() == "cheese")
            {
                return 1.1;
            }
                
            return 0.9;
        }
    }
}
