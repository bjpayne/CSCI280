using System;

namespace depthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            Model model = new Model();

            Employee root = model.BuildEmployeeGraph();

            Console.WriteLine("Traverse Nodes\n"+new String('-', "Traverse Nodes".Length));

            model.Traverse(root);

            Console.WriteLine("\nSearch For Nodes\n"+new String('-', "Search For Nodes".Length));

            String[] namesToSearchFor = {"Eva", "Brian", "Kris", "Adam", "Kay"};

            foreach (String nameToSearchFor in namesToSearchFor)
            {
                Employee employee = model.Search(root, nameToSearchFor);

                Console.WriteLine(employee == null ? $"{nameToSearchFor} not found." : $"{nameToSearchFor} found.");
            }
        }
    }
}