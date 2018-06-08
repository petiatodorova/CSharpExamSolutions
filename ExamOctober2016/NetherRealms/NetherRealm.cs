using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class NetherRealm
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x)
                .ToArray();

            string patternHealth = @"[^\d+\+\-\*\.\/\s\,]+";
            string patternNumbers = @"[\-\+]?[\d]+(?:\.\d+)?";

            Regex regexHealth = new Regex(patternHealth);
            Regex regexNumber = new Regex(patternNumbers);

            for (int i = 0; i < input.Length; i++)
            {
                long health = 0;
                double damages = 0.0F;
                string name = input[i];
                health = HealthSum(regexHealth, health, name);
                damages = DamagesSum(regexNumber, damages, name);
                Console.WriteLine($"{name} - {health} health, {damages:F2} damage");
            }
        }

        static double DamagesSum(Regex regexNumber, double damages, string name)
        {
            if (regexNumber.IsMatch(name))
            {
                MatchCollection matchesNumbers = regexNumber.Matches(name);

                foreach (Match number in matchesNumbers)
                {
                    string current = number.ToString();
                    damages += double.Parse(current);
                }

                foreach (char symbol in name.ToCharArray().Where(x => x == '*' | x == '/'))
                {
                    if (symbol == '*')
                    {
                        damages *= 2;
                    }
                    else
                    {
                        damages /= 2;
                    }
                }
            }

            return damages;
        }

        static long HealthSum(Regex regexHealth, long health, string name)
        {
            if (regexHealth.IsMatch(name))
            {
                MatchCollection matchesHealth = regexHealth.Matches(name);
                foreach (Match match in matchesHealth)
                {
                    char[] current = match.ToString().ToCharArray();
                    foreach (char letter in current)
                    {
                        health += (int)letter;
                    }
                }
            }

            return health;
        }
    }
}
