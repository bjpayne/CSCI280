using System;
using System.Collections.Generic;

namespace depthFirstSearch
{
    public class Employee
    {
        public String Name { get; }

        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Employee(String name)
        {
            Name = name;
        }

        public void IsEmployeeOf(Employee manager)
        {
            // Add subordinate instance to list of managers employees
            manager.Employees.Add(this);
        }

        public override String ToString()
        {
            return Name;
        }
    }
}