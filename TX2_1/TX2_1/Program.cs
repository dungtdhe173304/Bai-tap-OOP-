using System;
using System.Collections.Generic;
using System.Linq;

interface IEmployee
{
    int CalculateSalary();
    string GetName();
}

abstract class Employee : IEmployee
{
    protected string name;
    protected int paymentPerHour;

    public Employee(string name, int paymentPerHour)
    {
        this.name = name;
        this.paymentPerHour = paymentPerHour;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public void SetPaymentPerHour(int paymentPerHour)
    {
        this.paymentPerHour = paymentPerHour;
    }

    public int GetPaymentPerHour()
    {
        return paymentPerHour;
    }

    // Abstract method to calculate the salary, implementation provided by subclasses
    public abstract int CalculateSalary();

    // Abstract method to get employee type, implementation provided by subclasses
    public abstract string GetEmployeeType();

    // Override of ToString to provide a string representation of the employee
    public override string ToString()
    {
        return $"Name: {name}, Payment per Hour: {paymentPerHour}";
    }
}

class PartTimeEmployee : Employee
{
    private int workingHours;

    public PartTimeEmployee(string name, int paymentPerHour, int workingHours)
        : base(name, paymentPerHour)
    {
        this.workingHours = workingHours;
    }

    // Calculate the salary for a part-time employee
    public override int CalculateSalary()
    {
        return workingHours * paymentPerHour;
    }

    // Return the employee type as "PartTime"
    public override string GetEmployeeType()
    {
        return "PartTime";
    }

    // Override of ToString to provide a string representation of the part-time employee
    public override string ToString()
    {
        return base.ToString() + $", Type: {GetEmployeeType()}, Working Hours: {workingHours}, Salary: {CalculateSalary()}";
    }
}

class FullTimeEmployee : Employee
{
    public FullTimeEmployee(string name, int paymentPerHour)
        : base(name, paymentPerHour)
    {
    }

    // Calculate the salary for a full-time employee (assuming 8 hours per day)
    public override int CalculateSalary()
    {
        return 8 * paymentPerHour;
    }

    // Return the employee type as "FullTime"
    public override string GetEmployeeType()
    {
        return "FullTime";
    }

    // Override of ToString to provide a string representation of the full-time employee
    public override string ToString()
    {
        return base.ToString() + $", Type: {GetEmployeeType()}, Salary: {CalculateSalary()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        bool exit = false;

        // Main loop for menu selection
        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add employee");
            Console.WriteLine("2. List all employees");
            Console.WriteLine("3. Find employees by name");
            Console.WriteLine("4. Find employee with the highest salary (PartTime)");
            Console.WriteLine("5. Find employee with the highest salary (FullTime)");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployee(employees);
                    break;
                case "2":
                    ListAllEmployees(employees);
                    break;
                case "3":
                    FindEmployeeByName(employees);
                    break;
                case "4":
                    FindHighestPaidPartTimeEmployee(employees);
                    break;
                case "5":
                    FindHighestPaidFullTimeEmployee(employees);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Function to add a new employee
    static void AddEmployee(List<Employee> employees)
    {
        try
        {
            Console.WriteLine("Enter employee type:");
            Console.WriteLine("1. FullTime");
            Console.WriteLine("2. PartTime");
            Console.Write("Choose an option (1/2): ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter payment per hour: ");
            int paymentPerHour = int.Parse(Console.ReadLine());

            if (typeChoice == "1")
            {
                employees.Add(new FullTimeEmployee(name, paymentPerHour));
            }
            else if (typeChoice == "2")
            {
                Console.Write("Enter working hours: ");
                int workingHours = int.Parse(Console.ReadLine());
                employees.Add(new PartTimeEmployee(name, paymentPerHour, workingHours));
            }
            else
            {
                Console.WriteLine("Invalid employee type.");
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid input format: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error in adding employee: " + e.Message);
        }
    }

    // Function to find an employee by name
    static void FindEmployeeByName(List<Employee> employees)
    {
        Console.Write("Enter name to search: ");
        string searchName = Console.ReadLine();
        var foundEmployees = employees.Where(e => e.GetName().Equals(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundEmployees.Count > 0)
        {
            Console.WriteLine("Employees found:");
            foreach (var emp in foundEmployees)
            {
                Console.WriteLine(emp);
            }
        }
        else
        {
            Console.WriteLine("No employee found with the name " + searchName);
        }
    }

    // Function to find the highest paid full-time employee
    static void FindHighestPaidFullTimeEmployee(List<Employee> employees)
    {
        var highestPaidFullTime = employees.OfType<FullTimeEmployee>().OrderByDescending(e => e.CalculateSalary()).FirstOrDefault();
        Console.WriteLine("Highest paid FullTimeEmployee: " + (highestPaidFullTime != null ? highestPaidFullTime.ToString() : "None"));
    }

    // Function to find the highest paid part-time employee
    static void FindHighestPaidPartTimeEmployee(List<Employee> employees)
    {
        var highestPaidPartTime = employees.OfType<PartTimeEmployee>().OrderByDescending(e => e.CalculateSalary()).FirstOrDefault();
        Console.WriteLine("Highest paid PartTimeEmployee: " + (highestPaidPartTime != null ? highestPaidPartTime.ToString() : "None"));
    }

    // Function to list all employees
    static void ListAllEmployees(List<Employee> employees)
    {
        if (employees.Count > 0)
        {
            Console.WriteLine("All employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
        else
        {
            Console.WriteLine("No employees found.");
        }
    }
}
