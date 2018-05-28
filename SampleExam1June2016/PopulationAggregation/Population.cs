using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace PopulationAggregation
{
    class Population
    {
        static void Main(string[] args)
        {
            string pattern = @"[\@\#\$\&\d]";
            Regex regex = new Regex(pattern);

            SortedDictionary<string, int> countryTownsCount = new SortedDictionary<string, int>();
            Dictionary<string, long> cityPopulation = new Dictionary<string, long>();

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "stop")
                {
                    break;
                }

                string[] currentLine = input
                    .Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                currentLine[0] = CleaningName(regex, currentLine[0]);
                currentLine[1] = CleaningName(regex, currentLine[1]);
                string country;
                string city;

                if (Char.IsUpper(currentLine[0][0]))
                {
                    country = currentLine[0];
                    city = currentLine[1];
                }
                else
                {
                    city = currentLine[0];
                    country = currentLine[1];
                }

                long population = long.Parse(currentLine[2]);

                if (!countryTownsCount.ContainsKey(country))
                {
                    countryTownsCount.Add(country, 1);
                }
                else
                {
                    countryTownsCount[country]++;
                }

                if (!cityPopulation.ContainsKey(city))
                {
                    cityPopulation.Add(city, population);
                }
                else
                {
                    cityPopulation[city] = population;
                }

                input = Console.ReadLine();
            }

            //SortedDictionary<string, int> countryTownsCount = new SortedDictionary<string, int>();
            //Dictionary<string, long> cityPopulation = new Dictionary<string, long>();

            foreach (var kvp in countryTownsCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }

            int count = Math.Min(3, cityPopulation.Count);

            foreach (var pair in cityPopulation.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
                count--;
                if (count == 0)
                {
                    return;
                }
            }
        }

        static string CleaningName(Regex regex, string input)
        {
            if (regex.IsMatch(input))
            {
                return regex.Replace(input, "");
            }
            else
            {
                return input;
            }
        }
    }
}
