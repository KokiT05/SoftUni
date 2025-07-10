using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        // My code

        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.drinkOrders = new List<IDrink>();
            this.foodOrders = new List<IBakedFood>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

        }
        public int TableNumber { get { return this.tableNumber; } private set { this.tableNumber = value; } }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return this.pricePerPerson; }
            private set { this.pricePerPerson = value; }
        }

        public bool IsReserved { get { return this.isReserved; } private set { this.isReserved = value; } }

        public decimal Price { get { return this.PricePerPerson * this.NumberOfPeople; } }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
            decimal bill = 0;

            foreach (var food in this.foodOrders)
            {
                bill += food.Price;
            }

            foreach (var drink in this.drinkOrders)
            {
                bill += drink.Price;
            }

            bill += Price;

            return bill;

            //return this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(f => f.Price);
        }

        public string GetFreeTableInfo()
        {
            return $"Table: {this.TableNumber}{Environment.NewLine}" +
                    $"Type: {this.GetType().Name}{Environment.NewLine}" +
                    $"Capacity: {this.Capacity}{Environment.NewLine}" +
                    $"Price per Person: {this.PricePerPerson}";
        }

        public void OrderDrink(IDrink drink)
        {

            // From the lecture
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {

            // From the lecture
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
