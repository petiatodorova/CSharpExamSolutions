using System;
using System.Linq;

namespace TrophonTheGrumpyCat
{
    class TheGrumpyCat
    {
        static void Main(string[] args)
        {
            long[] prices = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            int entryPoint = int.Parse(Console.ReadLine());
            string typeOfItems = Console.ReadLine();
            string typeOfPriceRatings = Console.ReadLine();

            long leftSum = 0;
            long rightSum = 0;

            if (typeOfItems == "cheap" && typeOfPriceRatings == "positive")
            {
                leftSum = prices
                    .Take(entryPoint)
                    .Where(x => x > 0 && x < prices[entryPoint]).Sum();

                rightSum = prices
                    .Skip(entryPoint + 1)
                    .Where(x => x > 0 && x < prices[entryPoint]).Sum();
            }
            else if (typeOfItems == "expensive" && typeOfPriceRatings == "positive")
            {
                leftSum = prices
                   .Take(entryPoint)
                   .Where(x => x > 0 && x >= prices[entryPoint]).Sum();

                rightSum = prices
                    .Skip(entryPoint + 1)
                    .Where(x => x > 0 && x >= prices[entryPoint]).Sum();
            }
            else if (typeOfItems == "cheap" && typeOfPriceRatings == "negative")
            {
                leftSum = prices
                   .Take(entryPoint)
                   .Where(x => x < 0 && x < prices[entryPoint]).Sum();

                rightSum = prices
                    .Skip(entryPoint + 1)
                    .Where(x => x < 0 && x < prices[entryPoint]).Sum();
            }
            else if (typeOfItems == "expensive" && typeOfPriceRatings == "negative")
            {
                leftSum = prices
                   .Take(entryPoint)
                   .Where(x => x < 0 && x >= prices[entryPoint]).Sum();

                rightSum = prices
                    .Skip(entryPoint + 1)
                    .Where(x => x < 0 && x >= prices[entryPoint]).Sum();
            }
            else if (typeOfItems == "cheap" && typeOfPriceRatings == "all")
            {
                leftSum = prices
                   .Take(entryPoint)
                   .Where(x => x < prices[entryPoint]).Sum();

                rightSum = prices
                    .Skip(entryPoint + 1)
                    .Where(x => x < prices[entryPoint]).Sum();
            }
            else
            {
                leftSum = prices
                   .Take(entryPoint)
                   .Where(x => x >= prices[entryPoint]).Sum();

                rightSum = prices
                    .Skip(entryPoint + 1)
                    .Where(x => x >= prices[entryPoint]).Sum();
            }

            if (leftSum >= rightSum)
            {
                Console.WriteLine($"Left - {leftSum}");
            }
            else
            {
                Console.WriteLine($"Right - {rightSum}");
            }
        }
    }
}
