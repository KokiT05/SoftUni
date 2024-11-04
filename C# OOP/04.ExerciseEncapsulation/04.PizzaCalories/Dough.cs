using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Dough
    {
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
                if (value != "white" && value != "wholegrain")
                {
                    throw new Exception("Invalid type of dough.");
                }

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
                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new Exception("Invalid type of dough.");
                }

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
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

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
            if (this.FlourType == "white")
            {
                return 1.5;
            }

            return 1.0;
        }

        private double BakingTechniqueModifier()
        {
            if (this.BakingTechnique == "crispy")
            {
                return 0.9;
            }
            else if (this.BakingTechnique == "chewy")
            {
                return 1.1;
            }

            return 1.0;
        }
    }
}
