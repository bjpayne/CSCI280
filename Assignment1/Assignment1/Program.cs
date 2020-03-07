using System;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Threading;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                String[] choices = new String[] {"1", "2", "3"};

                String choice = "";

                while (!choices.Contains(choice))
                {
                    String selection = "1:\tAND\n";
                    selection += "2:\tOR\n";
                    selection += "3:\tXOR\n";
                    selection += "Please choose which operator to test: ";

                    Console.Write(selection);

                    choice = Console.ReadLine();
                }

                Boolean parsedFirstNumber = false;

                Int32 firstNumber = 0;

                while (!parsedFirstNumber)
                {
                    Console.Write("Enter first number: ");

                    parsedFirstNumber = Int32.TryParse(Console.ReadLine(), out firstNumber);
                }

                Boolean parsedSecondNumber = false;

                Int32 secondNumber = 0;

                while (!parsedSecondNumber)
                {
                    Console.Write("Enter second number: ");

                    parsedSecondNumber = Int32.TryParse(Console.ReadLine(), out secondNumber);
                }

                Int32 result;

                switch (choice)
                {
                    case "1":
                        result = firstNumber & secondNumber;
                        Console.WriteLine("Bitwise AND: " + result);
                        break;
                    case "2":
                        result = firstNumber | secondNumber;
                        Console.WriteLine("Bitwise OR: " + result);
                        break;
                    case "3":
                        result = firstNumber ^ secondNumber;
                        Console.WriteLine("Bitwise XOR: " + result);
                        break;
                }

                Console.WriteLine("Press Enter to run another test...");

                Console.ReadLine();
            }
        }
    }
}