using System;
using System.Globalization;
using System.Numerics;

namespace SinoTheWalker
{
    class TheWalker
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string format = "HH:mm:ss";
            DateTime timeLeaving = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture);

            int stepsCount = int.Parse(Console.ReadLine()) % 86400;
            int timeInSeconds = int.Parse(Console.ReadLine()) % 86400;

            // 86400 sec is 1 Day

            long sum = stepsCount * timeInSeconds;
            DateTime endTime = timeLeaving.AddSeconds(1.0*sum);
            int hours = endTime.Hour;
            int minutes = endTime.Minute;
            int seconds = endTime.Second;
            
            Console.WriteLine($"Time Arrival: {hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
