using System.Globalization;

namespace _01.CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<Department> departments = new List<Department>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] information = Console
                                                .ReadLine()
                                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = information[0];
                decimal salary = decimal.Parse(information[1]);
                string departmentName = information[2];
                Employee employee = new Employee(name, salary, departmentName);
                employees.Add(employee);

                foreach (Department currentDepartment in departments)
                {
                    if (currentDepartment.Name == departmentName)
                    {
                        currentDepartment.Salaries.Add(salary);
                    }
                }
                Department department = new Department(departmentName);
                departments.Add(department);
                department.Salaries.Add(salary);
            }

            decimal averageSalary = 0.0M;
            string averageSalaryDepartment = string.Empty;
            foreach (Department department in departments)
            {
                if (department.Salaries.Average() >= averageSalary)
                {
                    averageSalary = department.Salaries.Average();
                    averageSalaryDepartment = department.Name;
                }
            }

            Console.WriteLine($"Highest Average Salary: {averageSalaryDepartment}");
            employees = employees.OrderByDescending(s => s.Salary).ToList();
            foreach (Employee employee in employees)
            {
                if (employee.Department == averageSalaryDepartment)
                {
                    Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
                }
            }
        }
    }

    public class Employee
    {
        public Employee(string name, decimal salary, string department)
        {
            this.Name= name;
            this.Salary= salary;
            this.Department= department;
        }
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Department { get; set; }
    }

    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
            Salaries = new List<decimal>();
        }
        public string Name { get; set; }

        public List<decimal> Salaries { get; set; }
    }
}