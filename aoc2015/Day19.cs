using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day19
    {
        internal List<string[]> Replacements = new List<string[]>();
        internal string InputString = "";
        List<string> Variants = new List<string>();

        void Parse(string[] data)
        {
            foreach (var s in data)
            {
                if (s.Contains("=>"))
                {
                    var m = s.Split(' ');
                    Replacements.Add(new string[]{ m[0], m[2]});
                }
                else if (s.Length > 2)
                {
                    InputString = s;
                }
            }
        }

        void TryReplace(string from, string to)
        {
            var p = 0;
            var p1 = 0;

            p = InputString.IndexOf(from, p1);

            while (p >= 0)
            {
                p1 = p + 1;

                var s = InputString.Substring(0, p) + to + InputString.Substring(p + from.Length);

                if (Variants.All(v => v != s))
                {
                    Variants.Add(s);
                    Console.WriteLine($"Adding {s}");
                }

                p = InputString.IndexOf(from, p1);
            }
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day19.txt");

            /*
            var data = new string[]
            {
                "H => HO",
                "H => OH",
                "O => HH",
                "",
                "HOH",
            };
            */

            Parse(data);

            foreach (var r in Replacements)
            {
                Console.WriteLine($"{r[0]} => {r[1]}");
                TryReplace(r[0], r[1]);
            }

            Console.WriteLine($"Answer is {Variants.Count}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day19.txt");

            var values = data.Select(s => s.Select(c => c).ToArray()).ToArray();

            Console.WriteLine($"Answer is {42}");
        }
    }
}
