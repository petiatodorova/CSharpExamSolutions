using System;
using System.Linq;
using System.Collections.Generic;

namespace ArrayModifier
{
    class ModifyArray
    {
        static void Main(string[] args)
        {
            long[] arrNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "end")
                {
                    break;
                }

                string[] currentLine = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (currentLine[0])
                {
                    case "swap":
                        int index1 = int.Parse(currentLine[1]);
                        int index2 = int.Parse(currentLine[2]);
                        long temp = arrNumbers[index1];
                        arrNumbers[index1] = arrNumbers[index2];
                        arrNumbers[index2] = temp;
                        break;

                    case "multiply":
                        index1 = int.Parse(currentLine[1]);
                        index2 = int.Parse(currentLine[2]);
                        arrNumbers[index1] = arrNumbers[index1] * arrNumbers[index2];
                        break;

                    case "decrease":
                        for (int i = 0; i < arrNumbers.Length; i++)
                        {
                            arrNumbers[i]--;
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{string.Join(", ", arrNumbers)}");

        }
    }
}
