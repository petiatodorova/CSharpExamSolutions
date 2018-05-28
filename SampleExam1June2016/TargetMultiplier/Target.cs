using System;
using System.Linq;
using System.Collections.Generic;

namespace TargetMultiplier
{
    class Target
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int r = rowsCols[0];
            int c = rowsCols[1];

            int[,] matrix = new int[r, c];

            for (int row = 0; row < r; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < c; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            int[] indexes = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            int theRow = indexes[0];
            int theCol = indexes[1];

            int targetValue = matrix[theRow, theCol];
            int sum = 0;

            for (int rows = theRow - 1; rows <= theRow + 1; rows++)
            {
                for (int cols = theCol - 1; cols <= theCol + 1; cols++)
                {
                    if (rows == theRow && cols == theCol)
                    {
                        continue;
                    }
                    else
                    {
                        sum += matrix[rows, cols];
                        matrix[rows, cols] *= targetValue;
                    }
                }
            }

            matrix[theRow, theCol] = sum * targetValue;

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine($"");
            }
        }
    }
}
