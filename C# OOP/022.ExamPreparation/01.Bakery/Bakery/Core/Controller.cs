using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private  List<IBakedFood> bakedFoods;
        private  List<IDrink> drinks;
        private  List<ITable> tables;

        private decimal totalIncome = 0M;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
           

            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }

            this.drinks.Add(drink);


            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            //type = type.ToLower();

            IBakedFood bakedFood = null;

            if (type == "Bread")
            {
                bakedFood = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                bakedFood = new Cake(name, price);
            }

            this.bakedFoods.Add(bakedFood);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {

            ITable table = null;

            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(table);

            //return $"Added table number {tableNumber} in the bakery";
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder result = new StringBuilder();

            foreach (ITable table in this.tables.Where(t => t.IsReserved == false))
            {
                result.AppendLine(table.GetFreeTableInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            //decimal totalIncome = 0;

            //foreach (ITable table in this.tables)
            //{
            //    totalIncome += table.GetBill();
            //}
            return string.Format(OutputMessages.TotalIncome, this.totalIncome);
            //return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            totalIncome += table.GetBill() + table.Price;
            decimal tableBill = table.GetBill() + table.Price;

            table.Clear();

            return $"Table: {tableNumber}{Environment.NewLine}" +
                    $"Bill: {tableBill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
                //return $"Could not find table {tableNumber}";
            }

            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (drink == null)
            {
                return string.Format(OutputMessages.DrinkAdded, drinkName, drinkBrand);
                //return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, drinkName, drinkBrand);
            //return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
                //return $"Could not find table {tableNumber}";
            }

            IBakedFood bakedFood = this.bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (bakedFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
                //return $"No {foodName} in the menu";
            }

            table.OrderFood(bakedFood);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
            //return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
                //return $"No available table for {numberOfPeople} people";
            }

            table.Reserve(numberOfPeople);

            //return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
