using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Sue
    {
        public Dictionary<string, int> Stuff { get; } = new Dictionary<string, int>();

        public string Name { get; set; }

        public Sue(string s)
        {
            var m = s.Split(' ').Select(item => item.TrimEnd(new char[]{':',','})).ToArray();

            Name = m[0] + " " + m[1];

            Stuff[m[2]] = Int32.Parse(m[3]);
            Stuff[m[4]] = Int32.Parse(m[5]);
            Stuff[m[6]] = Int32.Parse(m[7]);
        }

        public bool CanHave(string item, int number)
        {
            return !Stuff.ContainsKey(item) || Stuff[item] == number;
        }

        public bool CanHavePart2(string item, int number)
        {
            if (!Stuff.ContainsKey(item))
            {
                return true;
            }

            if (item == "cats" || item == "trees")
            {
                return Stuff[item] > number;
            }
            else if (item == "pomeranians" || item == "goldfish")
            {
                return Stuff[item] < number;
            }
            else
            {
                return Stuff[item] == number;
            }
        }
    }

    internal class Day16
    {
        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day16.txt");

            var Sues = data.Select(s => new Sue(s)).ToList();

            Dictionary<string, int> key = new Dictionary<string, int>()
            {
                { "children", 3 },
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 },
            };

            var candidates = Sues;
            foreach (var item in key.Keys)
            {
                candidates = candidates.Where(c => c.CanHave(item, key[item])).ToList();
                Console.WriteLine($"Applying {item} = {key[item]}, {candidates.Count} candidates left");
            }

            if (candidates.Count != 1)
            {
                Console.WriteLine("Answer: Unsolvable!");
            }
            else
            {
                Console.WriteLine($"Answer is {candidates.First().Name}");
            }
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day16.txt");

            var Sues = data.Select(s => new Sue(s)).ToList();

            Dictionary<string, int> key = new Dictionary<string, int>()
            {
                { "children", 3 },
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 },
            };

            var candidates = Sues;
            foreach (var item in key.Keys)
            {
                candidates = candidates.Where(c => c.CanHavePart2(item, key[item])).ToList();
                Console.WriteLine($"Applying {item} = {key[item]}, {candidates.Count} candidates left");
            }

            if (candidates.Count != 1)
            {
                Console.WriteLine("Answer: Unsolvable!");
            }
            else
            {
                Console.WriteLine($"Answer is {candidates.First().Name}");
            }

        }
    }
}
