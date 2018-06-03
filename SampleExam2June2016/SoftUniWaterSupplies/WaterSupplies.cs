using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniWaterSupplies
{
    class WaterSupplies
    {
        static void Main(string[] args)
        {
            double totalWater = int.Parse(Console.ReadLine());

            double[] bottles = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            double bottleCapacity = double.Parse(Console.ReadLine());

            int length = bottles.Length;
            double neededWater = 0;
            double remainingWater = totalWater;
            double currentFill;
            int index = -1;

            if (totalWater % 2 == 0)
            {
                for (int i = 0; i < length; i++)
                {
                    currentFill = bottleCapacity - bottles[i];
                    if (currentFill <= remainingWater)
                    {
                        remainingWater = remainingWater - currentFill;
                    }
                    else
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine($"Enough water!");
                    Console.WriteLine($"Water left: {remainingWater}l.");
                }
                else
                {
                    Console.WriteLine($"We need more water!");
                    Console.WriteLine($"Bottles left: {length - index}");

                    Console.Write($"With indexes: ");
                    for (int m = index; m < length - 1; m++)
                    {
                        Console.Write($"{m}, ");
                    }
                    Console.WriteLine(length - 1);
                    for (int l = index; l < length; l++)
                    {
                        currentFill = bottleCapacity - bottles[l];
                        neededWater += currentFill;
                    }
                    neededWater -= remainingWater;

                    Console.WriteLine($"We need {neededWater} more liters!");
                }
            }
            else
            {
                for (int i = length - 1; i >= 0; i--)
                {
                    currentFill = bottleCapacity - bottles[i];
                    if (currentFill <= remainingWater)
                    {
                        remainingWater = remainingWater - currentFill;
                    }
                    else
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine($"Enough water!");
                    Console.WriteLine($"Water left: {remainingWater}l.");
                }
                else
                {
                    Console.WriteLine($"We need more water!");
                    Console.WriteLine($"Bottles left: {index + 1}");

                    Console.Write($"With indexes: ");
                    for (int m = index; m > 0; m--)
                    {
                        Console.Write($"{m}, ");
                    }
                    Console.WriteLine(0);
                    for (int l = index; l >= 0; l--)
                    {
                        currentFill = bottleCapacity - bottles[l];
                        neededWater += currentFill;
                    }
                    neededWater -= remainingWater;

                    Console.WriteLine($"We need {neededWater} more liters!");
                }
            }
        }
    }
}
