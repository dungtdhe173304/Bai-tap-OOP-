using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX2_2
{
    // Customer class inheriting from Person class
    class Customer : Person
    {
        private int balance;

        // Constructor to initialize Customer object with id, name, address, and balance
        public Customer(int id, string name, string address, int balance) : base(id, name, address)
        {
            this.balance = balance;
        }

        // Method to get the balance of the customer
        public int GetBalance()
        {
            return balance;
        }

        // Override of Display method to show customer details
        public override void Display()
        {
            Console.WriteLine("Customer ID: " + id);
            Console.WriteLine("Customer Name: " + name);
            Console.WriteLine("Customer Address: " + address);
            Console.WriteLine("Customer Balance: " + balance);
            Console.WriteLine("\n");
        }
    }
}
