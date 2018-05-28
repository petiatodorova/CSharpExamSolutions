using System;
using System.Linq;
using System.Collections.Generic;

namespace EnduranceRally
{
    class Rally
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<double> zones = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList();

            List<int> checkpointIndexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < names.Length; i++)
            {
                string currentName = names[i];
                double fuel = currentName[0];
                for (int j = 0; j < zones.Count; j++)
                {
                    if (checkpointIndexes.Contains(j))
                    {
                        fuel = fuel + zones[j];
                    }
                    else
                    {
                        fuel = fuel - zones[j];
                    }
                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{currentName} - reached {j}");
                        break;
                    }
                }
                if (fuel > 0)
                {
                    Console.WriteLine($"{currentName} - fuel left {fuel:F2}");
                }
            }
        }
    }
}
