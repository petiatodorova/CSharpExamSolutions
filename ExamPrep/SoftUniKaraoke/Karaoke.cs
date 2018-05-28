using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniKaraoke
{
    class Karaoke
    {
        public static void Main()
        {
            List<string> participantsInput = Console.ReadLine()
                .Split(',')
                .Select(p => p.Trim())
                .ToList();

            List<string> songs = Console.ReadLine()
                .Split(',')
                .Select(s => s.Trim())
                .ToList();

            Dictionary<string, List<string>> personsAwards = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "dawn")
            {
                List<string> current = input
                    .Split(',')
                    .Select(p => p.Trim())
                    .ToList();

                string participant = current[0];
                string song = current[1];
                string award = current[2];

                if (participantsInput.Contains(participant) && songs.Contains(song))
                {
                    if (!personsAwards.ContainsKey(participant))
                    {
                        personsAwards[participant] = new List<string>();
                    }
                   
                    if (!personsAwards[participant].Contains(award))
                    {
                        personsAwards[participant].Add(award);
                    }
                }
                input = Console.ReadLine();
            }
            if (personsAwards.Any())
            {
                foreach (var keyValuePair in personsAwards.OrderByDescending(p => p.Value.Count).ThenBy(n => n.Key))
                {
                    if (keyValuePair.Key.Any())
                    {
                        var participant = keyValuePair.Key;
                        var awards = keyValuePair.Value;
                        Console.WriteLine($"{participant}: {awards.Count} awards");
                        foreach (var award in awards.OrderBy(n => n))
                        {
                            Console.WriteLine($"--{award}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }
        }
    }
}

