using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string InvalidDoughExceptionMessage = "Invalid type of dough.";

        private double weight;
        private string flourType;
        private string bakingTechnique;
        private const double CaloriesPerGram = 2;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                Validator.ThrowIfValueIsNotAllowed
                    (new HashSet<string> { "white", "wholegrain"}, 
                    value.ToLower(),
                    InvalidDoughExceptionMessage);

                //if (value != "white" && value != "wholegrain")
                //{
                //    throw new ArgumentException(invalidDoughExceptionMessage);
                //}

                this.flourType = value;
            }
        }
        public string BakingTechnique 
        {
            get
            {
                return this.bakingTechnique;
            }

            private set
            {
                Validator.ThrowIfValueIsNotAllowed
                    (new HashSet<string> { "crispy", "chewy", "homemade" }, 
                    value.ToLower(),
                    InvalidDoughExceptionMessage);

                //if (value != "crispy" && value != "chewy" && value != "homemade")
                //{
                //    throw new ArgumentException(invalidDoughExceptionMessage);
                //}

                this.bakingTechnique = value;
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
                $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");

                //if (value < minWeight || value > maxWeight)
                //{
                //    throw new ArgumentException
                //        ($"Dough weight should be in the range [{minWeight}..{maxWeight}].");
                //}

                this.weight = value;
            }
        }

        public double TotalCalories => this.TotalCaloriesMethod();

        private double TotalCaloriesMethod()
        {
            double totalCalories = (2 * this.Weight) * 
                                this.FlourTypeModifier() *
                                this.BakingTechniqueModifier();

            return totalCalories;
        }

        private double FlourTypeModifier()
        {
            if (this.FlourType.ToLower() == "white")
            {
                return 1.5;
            }

            return 1.0;
        }

        private double BakingTechniqueModifier()
        {
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                return 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                return 1.1;
            }

            return 1.0;
        }
    }
}
