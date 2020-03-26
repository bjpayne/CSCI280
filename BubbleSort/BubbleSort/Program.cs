using System;
using System.Collections.Immutable;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32[] listSizes = new Int32[] {100, 1000, 10000, 25000, 50000, 100000, 250000, 500000, 750000, 1000000};

            foreach (Int32 size in listSizes)
            {
                Int32[] randomList = GenerateRandomList(size, 0, 100);

                BubbleSort(randomList);
                
                randomList = GenerateRandomList(size, 0, 100);

                BuiltInSort(randomList);
            }
        }

        static Int32[] GenerateRandomList(Int32 size, Int32 min, Int32 max)
        {
            Random randNum = new Random();
            
            Int32[] randomList = Enumerable
                .Repeat(0, size)
                .Select(i => randNum.Next(min, max))
                .ToArray();

            return randomList;
        }

        static void BubbleSort(Int32[] randomList)
        {
            DateTime start = DateTime.Now;
            DateTime end;

            Int32 randomListLength = randomList.Length;

            for (Int32 i = 0; i < randomListLength - 1; i++)
            {
                for (Int32 j = 0; j < randomListLength - i - 1; j++)
                {
                    if (randomList[j] > randomList[j + 1])
                    {
                        Int32 temp = randomList[j];

                        randomList[j] = randomList[j + 1];

                        randomList[j + 1] = temp;
                    }
                }
            }

            end = DateTime.Now;

            TimeSpan timeSpan = end.Subtract(start);

            Console.WriteLine("Bubble Sort duration for {0} elements = {1} ms", randomListLength, timeSpan.TotalMilliseconds);
        }

        static Int32[] BuiltInSort(Int32[] randomList)
        {
            DateTime start = DateTime.Now;
            DateTime end;

            Array.Sort(randomList);

            end = DateTime.Now;

            TimeSpan timeSpan = end.Subtract(start);

            Console.WriteLine("Builtin duration for {0} elements = {1} ms", randomList.Length, timeSpan.TotalMilliseconds);

            return randomList;
        }
    }
}