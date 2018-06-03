using System;

namespace SoftUniAirline
{
    class Airline
    {
        static void Main(string[] args)
        {

            int flightsCount = int.Parse(Console.ReadLine());
            decimal overallProfit = 0.0M;
            decimal averageProfit = 0.0M;


            for (int i = 0; i < flightsCount; i++)
            {
                int adultPassengers = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                int youthPassengers = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                decimal income = (adultPassengers * adultTicketPrice) + (youthPassengers * youthTicketPrice)
                                    - (flightDuration * fuelConsumptionPerHour * fuelPricePerHour);

                if (income >= 0)
                {
                    Console.WriteLine($"You are ahead with {income:F3}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {income:F3}$.");
                }
                overallProfit = overallProfit + income;
            }

            averageProfit = overallProfit / flightsCount;

            Console.WriteLine($"Overall profit -> {overallProfit:F3}$.");
            Console.WriteLine($"Average profit -> {averageProfit:F3}$.");
        }
    }
}
