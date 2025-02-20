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

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
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

        public readonly ICollection<IBakedFood> FoodOrders;
        public readonly ICollection<IDrink> DrinkOrders;

        public void Clear()
        {
            this.FoodOrders.Clear();
            this.DrinkOrders.Clear();
            this.IsReserved = false;
            this.NumberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.FoodOrders.Sum(f => f.Price) + this.DrinkOrders.Sum(f => f.Price);
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
            this.DrinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
