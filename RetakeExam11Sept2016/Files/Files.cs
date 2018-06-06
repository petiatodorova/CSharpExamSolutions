using System;
using System.Linq;
using System.Collections.Generic;

namespace Files
{
    class Files
    {
        static void Main(string[] args)
        {
            int numberOfFiles = int.Parse(Console.ReadLine());

            //root | name | size
            Dictionary<string, Dictionary<string, long>> files = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < numberOfFiles; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(new char[] { ';', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int length = line.Length;
                string root = line[0];
                string name = line[length - 2];
                long size = long.Parse(line[length - 1]);

                if (!files.ContainsKey(root))
                {
                    Dictionary<string, long> current = new Dictionary<string, long>();
                    current.Add(name, size);
                    files.Add(root, current);
                }
                else if (!files[root].ContainsKey(name))
                {
                    files[root].Add(name, size);
                }
                else
                {
                    files[root][name] = size;
                }
            }

            string[] query = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            string theExtension = query[0];
            string theRoot = query[2];

            if (!files.ContainsKey(theRoot) || !files[theRoot].Any(x => x.Key.EndsWith(theExtension)))
            {
                Console.WriteLine($"No");
            }
            else
            {
                foreach (var nameSize in files[theRoot]
                    .Where(f => f.Key.EndsWith(theExtension))
                    .OrderByDescending(x => x.Value).ThenBy(y => y.Key))
                {
                    Console.WriteLine($"{nameSize.Key} - {nameSize.Value} KB");
                }
            }
        }
    }
}
