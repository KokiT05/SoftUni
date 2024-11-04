using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Topping
    {
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
                if (value != "meat" && 
                    value != "veggies" && 
                    value != "cheese" &&
                    value != "sauce")
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }

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
                if (value < 1 || value > 50)
                {
                    throw new Exception
                        ($"{this.ToppingType} weight should be in the range [1..50].");
                }
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
            if (this.ToppingType == "meat")
            {
                return 1.2;
            }
            else if (this.ToppingType == "veggies")
            {
                return 0.8;
            }
            else if (this.ToppingType == "cheese")
            {
                return 1.1;
            }
                
            return 0.9;
        }
    }
}
