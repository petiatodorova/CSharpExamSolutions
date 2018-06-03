using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniCoffeeSupplies
{
    class CoffeeSupplies
    {
        static void Main(string[] args)
        {
            string[] keywords = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string firstDelimiter = keywords[0];
            string secondDelimiter = keywords[1];

            Dictionary<string, string> personCoffee = new Dictionary<string, string>();
            Dictionary<string, long> coffeeQuantity = new Dictionary<string, long>();

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "end of info")
                {
                    break;
                }

                if (input.Contains(firstDelimiter))
                {
                    string[] parts = input
                    .Split(new string[] { firstDelimiter }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string person = parts[0];
                    string coffee = parts[1];

                    if (!personCoffee.ContainsKey(person))
                    {
                        personCoffee.Add(person, coffee);
                    }
                    else
                    {
                        personCoffee[person] = coffee;
                    }
                }

                if (input.Contains(secondDelimiter))
                {
                    string[] parts = input
                    .Split(new string[] { secondDelimiter }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                    string coffee = parts[0];
                    long quantity = 0;
                    if (parts.Length > 1)
                    {
                        quantity = long.Parse(parts[1]);
                    }

                    if (!coffeeQuantity.ContainsKey(coffee))
                    {
                        coffeeQuantity.Add(coffee, quantity);
                    }
                    else
                    {
                        coffeeQuantity[coffee] += quantity;
                    }
                }
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (true)
            {
                if (input == "end of week")
                {
                    break;
                }

                string[] parts = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string person = parts[0];
                long quantity = long.Parse(parts[1]);

                string coffee = "";

                if (personCoffee.ContainsKey(person))
                {
                    coffee = personCoffee[person];
                }

                if (coffeeQuantity.ContainsKey(coffee))
                {
                    coffeeQuantity[coffee] -= quantity;
                }

                input = Console.ReadLine();
            }

            List<string> coffeeNeeded = personCoffee.Values.ToList();
            List<string> coffeeAvailable = coffeeQuantity.Keys.ToList();

            foreach (var needed in coffeeNeeded)
            {
                if (!coffeeAvailable.Contains(needed))
                {
                    Console.WriteLine($"Out of {needed}");
                }
            }

            foreach (var kvp in coffeeQuantity.Where(x => x.Value <= 0))
            {
                Console.WriteLine($"Out of {kvp.Key}");
            }

            Console.WriteLine($"Coffee Left:");

            List<string> coffeePositive = new List<string>();

            foreach (var kvp in coffeeQuantity.Where(x => x.Value > 0).OrderByDescending(y => y.Value))
            {
                string coffee = kvp.Key;
                coffeePositive.Add(coffee);
                long quantity = kvp.Value;
                Console.WriteLine($"{coffee} {quantity}");
            }

            Console.WriteLine($"For:");

            foreach (var coffee in coffeePositive.OrderBy(x => x))
            {
                foreach (var pair in personCoffee.Where(y => y.Value == coffee).OrderByDescending(z => z.Key))
                {
                    Console.WriteLine($"{pair.Key} {pair.Value}");
                }
            }
        }
    }
}
