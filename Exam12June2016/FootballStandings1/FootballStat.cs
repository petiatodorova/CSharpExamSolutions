using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FootballStandings1
{
    class Team
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int Goals { get; set; }

        public Team(string name, int points, int goals)
        {
            Name = name;
            Points = points;
            Goals = goals;
        }
    }

    class FootballStat
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string escapedKey = Regex.Escape(key);
            string input = Console.ReadLine();

            string patternKey = @"(.*)" + escapedKey + @"(\w*)" + escapedKey + @"(.*)" + escapedKey + @"(\w*)" + escapedKey;
            string patternDigits = @"(\d+):(\d+)";

            Regex regexKey = new Regex(patternKey);
            Regex regexDigits = new Regex(patternDigits);

            List<Team> teams = new List<Team>();

            while (true)
            {
                if (input == "final")
                {
                    break;
                }

                // {encrypted teamA} {encrypted teamB} {teamA score}:{teamB score}
                string nameA = "";
                string nameB = "";
                int goalsA = 0;
                int goalsB = 0;
                int pointsA = 0;
                int pointsB = 0;

                if (regexKey.IsMatch(input) && regexDigits.IsMatch(input))
                {
                    Match match = regexKey.Match(input);
                    nameA = match.Groups[2].Value;
                    nameB = match.Groups[4].Value;
                    Match matchDigits = regexDigits.Match(input);
                    goalsA = int.Parse(matchDigits.Groups[1].Value);
                    goalsB = int.Parse(matchDigits.Groups[2].Value);

                    if (goalsA > goalsB)
                    {
                        pointsA = 3;
                        pointsB = 0;
                    }
                    else if (goalsA == goalsB)
                    {
                        pointsA = 1;
                        pointsB = 1;
                    }
                    else
                    {
                        pointsA = 0;
                        pointsB = 3;
                    }

                    nameA = ReverseString(nameA).ToUpper();
                    nameB = ReverseString(nameB).ToUpper();

                    TeamFill(teams, nameA, goalsA, pointsA);
                    TeamFill(teams, nameB, goalsB, pointsB);
                }

                input = Console.ReadLine();
            }

            // Print
            Console.WriteLine($"League standings:");

            int counter = 0;
            foreach (var team in teams.OrderByDescending(x => x.Points).ThenBy(y => y.Name))
            {
                counter++;
                Console.WriteLine($"{counter}. {team.Name} {team.Points}");
            }

            Console.WriteLine($"Top 3 scored goals:");
            counter = 1;
            foreach (var team in teams.OrderByDescending(x => x.Goals).ThenBy(y => y.Name))
            {
                Console.WriteLine($"- {team.Name} -> {team.Goals}");
                counter++;
                if (counter == 4)
                {
                    return;
                }
            }
        }

        // Fill in the List<Team> teams
        static void TeamFill(List<Team> teams, string nameA, int goalsA, int pointsA)
        {
            if (!teams.Any(x => x.Name == nameA))
            {
                Team team = new Team(nameA, pointsA, goalsA);
                teams.Add(team);
            }
            else
            {
                Team team = teams.FirstOrDefault(x => x.Name == nameA);
                team.Goals += goalsA;
                team.Points += pointsA;
            }
        }

        static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
