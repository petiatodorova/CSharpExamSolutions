using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrifonsQuest
{
    class Quest
    {
        static void Main(string[] args)
        {
            long health = long.Parse(Console.ReadLine());
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] letters = new char[rows][];

            for (int r = 0; r < rows; r++)
            {
                letters[r] = Console.ReadLine().ToCharArray();
            }

            long countTurns = 0;
            char theLetter;
            int row = 0;

            for (int col = 0; col < cols; col++)
            {
                for (int r = 0; r < rows; r++)
                {
                    if (col % 2 == 0)
                    {
                        row = r;
                    }
                    else
                    {
                        row = rows - 1 - r;
                    }
                    theLetter = letters[row][col];
                    Action(ref health, ref countTurns, theLetter);
                    if (health <= 0)
                    {
                        Console.WriteLine("Died at: [{0}, {1}]", row, col);
                        return;
                    }
                    countTurns++;

                }

            }

            Console.WriteLine("Quest completed!");
            Console.WriteLine("Health: {0}", health);
            Console.WriteLine("Turns: {0}", countTurns);
        }

        static void Action(ref long health, ref long countTurns, char theLetter)
        {
            switch (theLetter)
            {
                case 'F':

                    health = health - countTurns / 2;
                    break;

                case 'H':
                    health = health + countTurns / 3;
                    break;

                case 'T':
                    countTurns = countTurns + 2;
                    break;

                case 'E':
                    break;
            }
        }
    }
}
