using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX2_2
{
    // Employee class inheriting from Person class
    class Employee : Person
    {
        private int salary;

        // Constructor to initialize Employee object with id, name, address, and salary
        public Employee(int id, string name, string address, int salary) : base(id, name, address)
        {
            this.salary = salary;
        }

        // Method to get the salary of the employee
        public int GetSalary()
        {
            return salary;
        }

        // Override of Display method to show employee details
        public override void Display()
        {
            Console.WriteLine("Employee ID: " + id);
            Console.WriteLine("Employee Name: " + name);
            Console.WriteLine("Employee Address: " + address);
            Console.WriteLine("Employee Salary: " + salary);
            Console.WriteLine("\n");
        }
    }
}
