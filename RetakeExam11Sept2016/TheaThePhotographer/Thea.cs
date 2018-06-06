using System;

namespace TheaThePhotographer
{
    class Thea
    {
        static void Main(string[] args)
        {

            long amountOfPictures = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            double filterFactor = double.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());

            long totalTime = amountOfPictures * filterTime + (long)Math.Ceiling(amountOfPictures * filterFactor / 100) * uploadTime;

            long seconds = totalTime % 60;
            long allMinutes = totalTime / 60;
            long minutes = allMinutes % 60;
            long allHours = allMinutes / 60;
            long hours = allHours % 24;
            long days = allHours / 24;

            Console.WriteLine($"{days:D1}:{hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }
}
