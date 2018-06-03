using System;
using System.Linq;
using System.Collections.Generic;

namespace Numbers
{
    class TheNumbers
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            double average = numbers.Average();

            List<long> greaterNumbers = numbers
                .Where(x => x > average)
                .OrderByDescending(y => y)
                .ToList();

            int count = greaterNumbers.Count;

            if (count == 0)
            {
                Console.WriteLine($"No");
            }
            else
            {
                int printCount = Math.Min(count, 5);
                for (int i = 0; i < printCount; i++)
                {
                    Console.Write($"{greaterNumbers[i]} ");
                }
            }
        }
    }
}
