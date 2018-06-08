using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCoderRoli
{
    class RoliTheCoder
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> idName = new Dictionary<int, string>();
            Dictionary<string, List<string>> eventParticipants = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Time for Code"))
                {
                    break;
                }

                if (!input.Contains('#'))
                {
                    continue;
                }

                List<string> line = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                int id = int.Parse(line[0]);
                string eventName = "";
                if (!line[1].StartsWith("#"))
                {
                    continue;
                }
                eventName = line[1];

                if (line.Skip(2).Any(x => !x.StartsWith("@")))
                {
                    continue;
                }

                // Dictionary<int, string> eventIdName 
                // Dictionary<string, List<string>> eventsParticipants 
                if (!idName.ContainsKey(id))
                {
                    idName.Add(id, eventName);
                }
                else if (!idName[id].Equals(eventName))
                {
                    continue;
                }

                if (!eventParticipants.ContainsKey(eventName))
                {
                    List<string> current = new List<string>();
                    current.AddRange(line.Skip(2).Distinct());
                    eventParticipants.Add(eventName, current);
                }
                else
                {
                    foreach (var participant in line.Skip(2).Distinct())
                    {
                        if (!eventParticipants[eventName].Contains(participant))
                        {
                            eventParticipants[eventName].Add(participant);
                        }
                    }
                }
            }

            foreach (var kvp in eventParticipants.OrderByDescending(x => x.Value.Count).ThenBy(y => y.Key))
            {
                Console.WriteLine($"{kvp.Key.TrimStart('#')} - {kvp.Value.Count}");
                foreach (var participant in kvp.Value.OrderBy(z => z))
                {
                    Console.WriteLine($"{participant}");
                }
            }
        }
    }
}
