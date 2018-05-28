using System;

namespace SweetDessert
{
    class Dessert
    {
        static void Main(string[] args)
        {

            double ivanchosMoney = double.Parse(Console.ReadLine());
            int guestsNumber = int.Parse(Console.ReadLine());
            double bananasPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berriesPriceperKilo = double.Parse(Console.ReadLine());

            // For a set of 6 she needs 2 bananas, 4 eggs and 0.2 kilos berries.
            int setsCount = (int)Math.Ceiling(1.0 * guestsNumber / 6);
            double pricePerSet = 2 * bananasPrice + 4 * eggsPrice + 0.2 * berriesPriceperKilo;
            double totalSumNeeded = pricePerSet * setsCount;

            if (totalSumNeeded <= ivanchosMoney)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalSumNeeded:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(totalSumNeeded - ivanchosMoney):F2}lv more.");
            }
        }
    }
}
