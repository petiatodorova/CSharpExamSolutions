using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WinningTiketWithRegex
{
    class WinningTicketRegex
    {
        static void Main(string[] args)
        {
            string pattern = @"([\$]{6,}|[\#]{6,}|[\@]{6,}|[\^]{6,})";

            string[] tickets = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < tickets.Length; i++)
            {
                string currentTicket = tickets[i];

                if (currentTicket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                }
                else
                {
                    string leftSubstr = currentTicket.Substring(0, 10);
                    string rightSubstr = currentTicket.Substring(10, 10);
                    if (Regex.IsMatch(leftSubstr, pattern) && Regex.IsMatch(rightSubstr, pattern))
                    {
                        string leftMatch = Regex.Match(leftSubstr, pattern).ToString();
                        string rightMatch = Regex.Match(rightSubstr, pattern).ToString();

                        if (leftMatch.Contains(rightMatch) || rightMatch.Contains(leftMatch))
                        {
                            int length = Math.Min(leftMatch.Length, rightMatch.Length);
                            if (length <= 9)
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {length}{leftMatch[0]}");
                            }
                            else
                            {
                                Console.WriteLine($"ticket \"{currentTicket}\" - {length}{leftMatch[0]} Jackpot!");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{currentTicket}\" - no match");
                    }
                }
            }
        }
    }
}
