using System;

namespace CharityMarathon
{
    class Charity
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int runners = int.Parse(Console.ReadLine());
            int laps = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            int maxRunners = days * capacity;
            int finalRunners = Math.Min(runners, maxRunners);

            double totalMeters = 1.0 * finalRunners * laps * length;
            double totalKm = totalMeters / 1000;
            double totalMoney = totalKm * moneyPerKm;

            Console.WriteLine($"Money raised: {totalMoney:F2}"); 
        }
    }
}
