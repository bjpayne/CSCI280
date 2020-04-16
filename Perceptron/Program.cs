using System;

namespace Perceptron
{
    /**
     * Source:
     * Sporici, D. (2012, Sep 16). C# Perceptron Tutorial. Retrieved from
     * https://codingvision.net/miscellaneous/c-perceptron-tutorial
     */
    class Program
    {
        static void Main(string[] args)
        {
            String primaryInputRequest = "Please enter the first input (1 or 0): ";
            String secondaryInputRequest = "Please enter the second input (1 or 0): ";

            Int32 bias = 1;

            Int32 primaryInput;
            Int32 secondaryInput;

            Int32[,] input = new Int32[1, 2];

            Console.Write(primaryInputRequest);

            while (!Int32.TryParse(Console.ReadLine(), out primaryInput) ||
                   primaryInput > 1 ||
                   primaryInput < 0
            )
            {
                Console.Write($"\n{primaryInputRequest}");
            }

            Console.Write($"\nThank you! {secondaryInputRequest}");

            while (!Int32.TryParse(Console.ReadLine(), out secondaryInput) ||
                   secondaryInput > 1 ||
                   secondaryInput < 0
            )
            {
                Console.Write($"\n{secondaryInputRequest}");
            }

            input[0, 0] = primaryInput;
            input[0, 1] = secondaryInput;

            Int32[] outputs = {primaryInput, secondaryInput};

            Random random = new Random();

            Double[] weights = {random.NextDouble(), random.NextDouble(), random.NextDouble()};

            const Double learningRate = 1;

            Double totalError = 1;

            while (totalError > 0.2)
            {
                totalError = 0;
                
                Int32 output = CalculateOutput(input[0, 0], input[0, 1], weights);

                Int32 error = outputs[0] - output;

                weights[0] += learningRate * error * input[0, 0];
                weights[1] += learningRate * error * input[0, 1];
                weights[2] += learningRate * error * 1;

                totalError += Math.Abs(error);
            }

            Console.Write("Result: ");

            // Display the results
            Console.WriteLine(CalculateOutput(input[0, 0], input[0, 1], weights));

            for (Int32 i = 0; i < weights.Length; i++)
            {
                Console.WriteLine($"Random weight {i + 1}: {weights[i]}");
            }

            Console.ReadLine();
        }

        /**
         * Run the 
         */
        private static Int32 CalculateOutput(Double input1, Double input2, double[] weights)
        {
            // Bias must always be 1
            const Int32 bias = 1;
            
            Double sum = input1 * weights[0] + input2 * weights[1] + bias * weights[2];

            return (sum >= 0) ? 1 : 0;
        }
    }
}