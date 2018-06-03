using System;
using System.Linq;
using System.Collections.Generic;

namespace MatrixOperator
{
    class OperatorMatrix
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());

            List<List<int>> matrix = new List<List<int>>();
            for (int i = 0; i < r; i++)
            {
                matrix.Add(new List<int>());
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }

            matrix.RemoveAll(x => x.Count == 0);

            string input = Console.ReadLine();

            while (true)
            {
                if (input == "end")
                {
                    break;
                }
                string[] line = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (line[0])
                {
                    case "remove":
                        string type = line[1];
                        string rowOrCol = line[2];
                        int rowColNumber = int.Parse(line[3]);
                        switch (type)
                        {
                            case "positive":
                                RemovePositive(matrix, rowOrCol, rowColNumber);
                                break;

                            case "negative":
                                RemoveNegative(matrix, rowOrCol, rowColNumber);
                                break;

                            case "odd":
                                RemoveOdd(matrix, rowOrCol, rowColNumber);
                                break;

                            case "even":
                                RemoveEven(matrix, rowOrCol, rowColNumber);
                                break;
                        }
                        break;

                    case "swap":
                        int firstRow = int.Parse(line[1]);
                        int secondRow = int.Parse(line[2]);
                        if (CheckRow(matrix, firstRow) && CheckRow(matrix, secondRow))
                        {
                            List<int> help = matrix[firstRow];
                            matrix[firstRow] = matrix[secondRow];
                            matrix[secondRow] = help;
                        }
                        break;

                    case "insert":
                        int row = int.Parse(line[1]);
                        int number = int.Parse(line[2]);
                        
                        if (CheckRow(matrix, row))
                        {
                            matrix[row].Insert(0, number);
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            for (int n = 0; n < matrix.Count; n++)
            {
                Console.WriteLine($"{string.Join(" ", matrix[n])}");
            }
        }

        static bool CheckRow(List<List<int>> matrix, int row)
        {
            return row >= 0 && row <= matrix.Count;
        }

        static void RemoveEven(List<List<int>> matrix, string rowOrCol, int rowColNumber)
        {
            if (rowOrCol == "row")
            {
                int theRow = rowColNumber;
                if (CheckRow(matrix, theRow))
                {
                    List<int> helper = matrix[theRow].Where(x => x % 2 != 0).ToList();
                    matrix[theRow] = helper;
                }
            }
            else
            {
                int theCol = rowColNumber;
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (matrix[j].Count - 1 >= theCol && matrix[j][theCol] % 2 == 0)
                    {
                        matrix[j].RemoveAt(theCol);
                    }
                }
            }
        }

        static void RemoveOdd(List<List<int>> matrix, string rowOrCol, int rowColNumber)
        {
            if (rowOrCol == "row")
            {
                int theRow = rowColNumber;
                if (CheckRow(matrix, theRow))
                {
                    List<int> helper = matrix[theRow].Where(x => x % 2 == 0).ToList();
                    matrix[theRow] = helper;
                }  
            }
            else
            {
                int theCol = rowColNumber;
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (matrix[j].Count - 1 >= theCol && matrix[j][theCol] % 2 != 0)
                    {
                        matrix[j].RemoveAt(theCol);
                    }
                }
            }
        }

        static void RemoveNegative(List<List<int>> matrix, string rowOrCol, int rowColNumber)
        {
            if (rowOrCol == "row")
            {
                int theRow = rowColNumber;
                if (CheckRow(matrix, theRow))
                {
                    List<int> helper = matrix[theRow].Where(x => x >= 0).ToList();
                    matrix[theRow] = helper;
                }
            }
            else
            {
                int theCol = rowColNumber;
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (matrix[j].Count - 1 >= theCol && matrix[j][theCol] < 0)
                    {
                        matrix[j].RemoveAt(theCol);
                    }
                }
            }
        }

        static void RemovePositive(List<List<int>> matrix, string rowOrCol, int rowColNumber)
        {
            if (rowOrCol == "row")
            {
                int theRow = rowColNumber;
                if (CheckRow(matrix, theRow))
                {
                    List<int> helper = matrix[theRow].Where(x => x < 0).ToList();
                    matrix[theRow] = helper;
                }
            }
            else
            {
                int theCol = rowColNumber;
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (matrix[j].Count - 1 >= theCol && matrix[j][theCol] >= 0)
                    {
                        matrix[j].RemoveAt(theCol);
                    }
                }
            }
        }
    }
}
