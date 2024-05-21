using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX2_2
{
    using System;

    // Abstract base class Person
    abstract class Person
    {
        protected string name;
        protected string address;
        protected int id;

        // Constructor to initialize Person object with id, name, and address
        public Person(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        // Method to set the name of the person
        public void SetName(string name)
        {
            this.name = name;
        }

        // Method to get the name of the person
        public string GetName()
        {
            return name;
        }

        // Method to set the address of the person
        public void SetAddress(string address)
        {
            this.address = address;
        }

        // Method to get the address of the person
        public string GetAddress()
        {
            return address;
        }

        // Abstract method to display person details, to be implemented by derived classes
        public abstract void Display();
    }

}
