using System;
using System.Linq;

namespace Ladybugs
{
    class LafyBugsPr2
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize];
            int[] indexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int lengthFields = field.Length;

            for (int i = 0; i < indexes.Length; i++)
            {
                int currentValue = indexes[i];

                if (currentValue >= 0 && currentValue < lengthFields)
                {
                    field[currentValue] = 1;
                }
            }

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "end")
                {
                    break;
                }

                string[] query = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int bugIndex = int.Parse(query[0]);
                string direction = query[1];
                int flyLength = int.Parse(query[2]);

                if (bugIndex >= 0 && bugIndex < lengthFields)
                {
                    switch (direction)
                    {
                        case "left":
                            bugIndex = LeftDirection(field, lengthFields, bugIndex, flyLength);
                            break;

                        case "right":
                            bugIndex = RightDirection(field, lengthFields, bugIndex, flyLength);
                            break;
                    }

                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{string.Join(" ", field)}");
        }

        static int RightDirection(int[] field, int lengthFields, int bugIndex, int flyLength)
        {
            if (field[bugIndex] == 1)
            {
                if (flyLength >= 0)
                {
                    bugIndex = MoveRight(field, lengthFields, bugIndex, flyLength); 
                }
                else
                {
                    bugIndex = MoveLeft(field, lengthFields, bugIndex, -flyLength);
                }
            }
            return bugIndex;
        }

        static int LeftDirection(int[] field, int lengthFields, int bugIndex, int flyLength)
        {
            if (field[bugIndex] == 1)
            {
                if (flyLength >= 0)
                {
                    bugIndex = MoveLeft(field, lengthFields, bugIndex, flyLength);
                }
                else
                {
                    bugIndex = MoveRight(field, lengthFields, bugIndex, -flyLength);
                }
            }
            return bugIndex;
        }

        static int MoveLeft(int[] field, int lengthFields, int bugIndex, int flyLength)
        {
            field[bugIndex] = 0;
            while (true)
            {
                bugIndex -= flyLength;
                if (bugIndex >= 0 && field[bugIndex] == 0)
                {
                    field[bugIndex] = 1;
                    break;
                }
                if (bugIndex < 0)
                {
                    break;
                }
            }
            return bugIndex;
        }

        static int MoveRight(int[] field, int lengthFields, int bugIndex, int flyLength)
        {
            field[bugIndex] = 0;
            while (true)
            {
                bugIndex += flyLength;
                if (bugIndex < lengthFields && field[bugIndex] == 0)
                {
                    field[bugIndex] = 1;
                    break;
                }
                if (bugIndex >= lengthFields)
                {
                    break;
                }
            }
            return bugIndex;
        }
    }
}
