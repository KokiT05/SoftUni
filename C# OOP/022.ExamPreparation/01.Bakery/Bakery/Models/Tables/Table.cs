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
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        private decimal price;

        // Code from the lecture
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            // Code from the lecture
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();

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

        public decimal PricePerPerson { get { return this.pricePerPerson; } 
                                    private set { this.pricePerPerson = value; } }

        public bool IsReserved { get { return this.isReserved; } private set { this.isReserved = value; } }

        public decimal Price { get { return this.pricePerPerson * this.numberOfPeople; } }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.foodOrders.Sum(f => f.Price) + this.drinkOrders.Sum(f => f.Price);
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
