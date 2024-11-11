using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int NameMinLength = 1;
        private const int NameMaxLength = 15;

        private const int MinCountToppings = 0;
        private const int MaxCountToppings = 10;

        private string name;
        private readonly List<Topping> toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException
                        ($"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }
                else if (string.IsNullOrEmpty(value))
                {
                    throw new Exception();
                }

                this.name = value;
            }
        }

        public int NumberOfToppings => this.toppings.Count;
        //{
        //    get
        //    {
        //        if (this.toppings.Count > MaxCountToppings)
        //        {
        //            throw new Exception("Number of toppings should be in range [0..10].");
        //        }

        //        return this.toppings.Count;
        //    }
        //}

        public double TotalCalories => this.TotalCaloriesMethod();

        public IReadOnlyList<Topping> Toppings
        {
            get
            {
                return this.toppings.AsReadOnly();
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.NumberOfToppings > MaxCountToppings)
            {
                throw new Exception
                ($"Number of toppings should be in range [{MinCountToppings}..{MaxCountToppings}].");
            }

            this.toppings.Add(topping);
        }

        private double TotalCaloriesMethod()
        {
            double totalCalories = 0;
            totalCalories += this.Dough.TotalCalories;

            foreach (Topping topping in this.Toppings)
            {
                totalCalories += topping.TotalCalories;
            }

            return totalCalories;
        }
    }
}
