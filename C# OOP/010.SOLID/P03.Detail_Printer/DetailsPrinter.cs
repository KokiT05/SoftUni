﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                this.Print(employee);
            }
        }

        private void Print(Employee employee)
        {
            Console.WriteLine(employee.Details());
        }
    }
}
