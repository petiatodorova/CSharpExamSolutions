using System;
using System.Globalization;

namespace SoftuniCoffeeOrders
{
    class CoffeeOrders
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalSum = 0;
            decimal currentSum = 0;
            string dateFormat = "d/M/yyyy";

            for (int i = 0; i < n; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), dateFormat, DateTimeFormatInfo.InvariantInfo);
                decimal capsuleCount = decimal.Parse(Console.ReadLine());

                decimal daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                currentSum = pricePerCapsule * daysInMonth * capsuleCount;
                Console.WriteLine($"The price for the coffee is: ${currentSum:F2}");
                totalSum += currentSum;
                currentSum = 0;
            }
            Console.WriteLine($"Total: ${totalSum:F2}");
        }
    }
}
