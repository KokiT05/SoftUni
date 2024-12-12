using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            Employee employeeOne = new Employee("Ivan");
            employees.Add(employeeOne);

            Employee employeeTwo = new Employee("Velichkov");
            employees.Add(employeeTwo);

            Employee employeeTree = new Employee("Koki");
            employees.Add(employeeTree);

            List<string> documents = new List<string>() { "documentOne", "documentTwo" };
            Manager manager = new Manager("Petur", documents);
            employees.Add(manager);

            Manager managerTwo = new Manager("Daniel", documents);
            employees.Add(managerTwo);

            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();
        }
    }
}
