using TX2_2;
using System;
using System.Collections.Generic;

class MainClass
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        List<Customer> customers = new List<Customer>();
        int nextEmployeeId = 1;
        int nextCustomerId = 1;

        while (true)
        {
            // Display menu options
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Customer");
            Console.WriteLine("3. Display All Employees");
            Console.WriteLine("4. Display All Customers");
            Console.WriteLine("5. Find Employee with Highest Salary");
            Console.WriteLine("6. Find Customer with Lowest Balance");
            Console.WriteLine("7. Find Employee by Name");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            int choice;
            bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

            if (!isValidChoice)
            {
                Console.WriteLine("Invalid choice! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                // Add Employee
                case 1:
                    try
                    {
                        Console.Write("Enter employee name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter employee address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter employee salary: ");
                        int salary = int.Parse(Console.ReadLine());
                        employees.Add(new Employee(nextEmployeeId++, name, address, salary));
                        Console.WriteLine("Employee added successfully.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter the correct data type.");
                    }
                    break;

                // Add Customer
                case 2:
                    try
                    {
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter customer address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter customer balance: ");
                        int balance = int.Parse(Console.ReadLine());
                        customers.Add(new Customer(nextCustomerId++, name, address, balance));
                        Console.WriteLine("Customer added successfully.");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter the correct data type.");
                    }
                    break;

                // Display All Employees
                case 3:
                    foreach (Employee employee in employees)
                    {
                        employee.Display();
                    }
                    break;

                // Display All Customers
                case 4:
                    foreach (Customer customer in customers)
                    {
                        customer.Display();
                    }
                    break;

                // Find Employee with Highest Salary
                case 5:
                    if (employees.Count > 0)
                    {
                        Employee highestSalaryEmployee = employees[0];
                        foreach (Employee employee in employees)
                        {
                            if (employee.GetSalary() > highestSalaryEmployee.GetSalary())
                            {
                                highestSalaryEmployee = employee;
                            }
                        }
                        Console.WriteLine("Employee with the highest salary:");
                        highestSalaryEmployee.Display();
                    }
                    else
                    {
                        Console.WriteLine("No employees available.");
                    }
                    break;

                // Find Customer with Lowest Balance
                case 6:
                    if (customers.Count > 0)
                    {
                        Customer lowestBalanceCustomer = customers[0];
                        foreach (Customer customer in customers)
                        {
                            if (customer.GetBalance() < lowestBalanceCustomer.GetBalance())
                            {
                                lowestBalanceCustomer = customer;
                            }
                        }
                        Console.WriteLine("Customer with the lowest balance:");
                        lowestBalanceCustomer.Display();
                    }
                    else
                    {
                        Console.WriteLine("No customers available.");
                    }
                    break;

                // Find Employee by Name
                case 7:
                    Console.Write("Enter employee name to search: ");
                    string searchName = Console.ReadLine();
                    bool found = false;
                    foreach (Employee employee in employees)
                    {
                        if (employee.GetName().Equals(searchName, StringComparison.OrdinalIgnoreCase))
                        {
                            employee.Display();
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Employee not found.");
                    }
                    break;

                // Exit the program
                case 8:
                    Console.WriteLine("Exiting...");
                    return;

                // Handle invalid choices
                default:
                    Console.WriteLine("Invalid choice! Please choose a valid option.");
                    break;
            }
        }
    }
}
