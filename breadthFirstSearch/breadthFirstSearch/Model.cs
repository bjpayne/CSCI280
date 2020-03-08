using System;
using System.Collections.Generic;
using System.Linq;

namespace depthFirstSearch
{
    public class Model
    {
        public Employee BuildEmployeeGraph()
        {
            Employee eva = new Employee("Eva");
            Employee sophia = new Employee("Sophia");
            Employee brian = new Employee("Brian");
            Employee lisa = new Employee("Lisa");
            Employee tina = new Employee("Tina");
            Employee john = new Employee("John");
            Employee mike = new Employee("Mike");
            Employee tim = new Employee("Tim");
            Employee sara = new Employee("Sara");
            Employee daniel = new Employee("Daniel");
            Employee larry = new Employee("Larry");
            Employee bob = new Employee("Bob");
            Employee adam = new Employee("Adam");
            Employee paula = new Employee("Paula");
            Employee steven = new Employee("Steven");
            Employee jessica = new Employee("Jessica");
            Employee pam = new Employee("Pam");
            Employee tabatha = new Employee("Tabatha");
            Employee kris = new Employee("Kris");

            // Evas' employees
            sophia.IsEmployeeOf(eva);
            brian.IsEmployeeOf(eva);
            lisa.IsEmployeeOf(eva);

            // Sophias' employees
            tina.IsEmployeeOf(sophia);
            john.IsEmployeeOf(sophia);

            // Brians' employees
            mike.IsEmployeeOf(brian);
            tim.IsEmployeeOf(brian);

            // Lisas employees
            sara.IsEmployeeOf(lisa);
            daniel.IsEmployeeOf(lisa);

            // Tinas' employees
            larry.IsEmployeeOf(tina);
            bob.IsEmployeeOf(tina);

            // Johns employees
            adam.IsEmployeeOf(john);
            paula.IsEmployeeOf(john);

            // Mikes employees
            steven.IsEmployeeOf(mike);
            jessica.IsEmployeeOf(pam);

            // Tims' employees
            tabatha.IsEmployeeOf(tim);
            kris.IsEmployeeOf(eva); // Test BFS algorithm. Kris is listed fourth but added last.

            return eva;
        }

        public void Traverse(Employee root)
        {
            // Keep all employees in BFS order
            Queue<Employee> bfsOrder = new Queue<Employee>();

            // Keep track of managers
            Queue<Employee> employees = new Queue<Employee>();

            // Keep track of manager subordinates
            HashSet<Employee> subordinates = new HashSet<Employee>();

            employees.Enqueue(root);

            subordinates.Add(root);

            while (employees.Count > 0)
            {
                Employee employee = employees.Dequeue();

                bfsOrder.Enqueue(employee);

                foreach (Employee subordinate in employee.Employees)
                {
                    if (!subordinates.Contains(subordinate))
                    {
                        // Track the parent node
                        employees.Enqueue(subordinate);

                        // Track the child nodes
                        subordinates.Add(subordinate);
                    }
                }
            }

            while (bfsOrder.Count > 0)
            {
                Employee employee = bfsOrder.Dequeue();

                Console.WriteLine(employee);
            }
        }

        public Employee Search(Employee root, String nameToSearchFor)
        {
            // Parent Node
            Queue<Employee> employees = new Queue<Employee>();

            // Child nodes
            HashSet<Employee> subordinates = new HashSet<Employee>();

            employees.Enqueue(root);

            subordinates.Add(root);

            while (employees.Count > 0)
            {
                Employee employee = employees.Dequeue();

                if (employee.Name == nameToSearchFor)
                {
                    return employee;
                }

                foreach (Employee subordinate in employee.Employees)
                {
                    if (!subordinates.Contains(subordinate))
                    {
                        // Track the parent nodes
                        employees.Enqueue(subordinate);

                        // Track the child nodes
                        subordinates.Add(subordinate);
                    }
                }
            }

            return null;
        }
    }
}