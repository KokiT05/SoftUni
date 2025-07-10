using Microsoft.EntityFrameworkCore;

namespace ORMFundamentalsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestCompanyContext context = new TestCompanyContext();

            Department newDepartment = new Department();
            newDepartment.Name = "New Department";

            Employee newEmployee = new Employee();
            newEmployee.FirstName = "New";
            newEmployee.LastName = "Employee";
            newEmployee.Age = 111;
            newEmployee.DepartmentId = 4;

            context.Departments.Add(newDepartment);
            context.Employees.Add(newEmployee);
            context.SaveChanges();

            List<Employee> employees = context.Employees.ToList();

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Age}");
            }
        }
    }
}
