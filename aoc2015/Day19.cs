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

        void TryReplace(string input, string from, string to)
        {
            var p = 0;
            var p1 = 0;

            p = input.IndexOf(from, p1);

            while (p >= 0)
            {
                p1 = p + 1;

                var s = input.Substring(0, p) + to + input.Substring(p + from.Length);

                if (Variants.All(v => v != s))
                {
                    Variants.Add(s);
                    //Console.WriteLine($"Adding {s}");
                }

                p = input.IndexOf(from, p1);
            }
        }

        string Reduce(string input)
        {
            var a = Replacements.OrderByDescending(l => l[1].Length).ToArray();

            foreach (var r in a)
            {
                var p = input.IndexOf(r[1]);

                if (p >= 0)
                {
                    return input.Substring(0, p) + r[0] + input.Substring(p + r[1].Length);
                }
            }

            return input;
        }

        int Likeness(string target, string candidate)
        {
            if (candidate.Length > target.Length)
            {
                return -999999;
            }

            int matches = 0;
            for (int i = 0; i < candidate.Length; i++)
            {
                if (candidate[i] == target[i])
                {
                    matches++;
                }
                if (candidate[candidate.Length - 1 - i] == target[target.Length - 1 - i])
                {
                    matches++;
                }
            }

            return matches * 10 + target.Length - candidate.Length;
        }

        int MinReplacements = 999999999;

        bool Iterate(string s, int replacements)
        {
            Variants.Clear();

            foreach (var r in Replacements)
            {
                //Console.WriteLine($"{r[0]} => {r[1]}");
                TryReplace(InputString, r[0], r[1]);
            }

            if (Variants.Any(v => v == InputString))
            {
                if (replacements + 1 < MinReplacements)
                {
                    MinReplacements = replacements + 1;
                }
                return true;
            }

            var vv = Variants.Select(v => new Tuple<int, string>(Likeness(InputString, v), v)).OrderByDescending(t => t.Item1).Where(testc => testc.Item1 > -999999).ToList();

            if (vv.Count == 0)
            {
                return false;
            }

            foreach (var item in vv)
            {
                if (Iterate(item.Item2, replacements + 1))
                {
                    return true;
                }
            }

            return false;
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
                //Console.WriteLine($"{r[0]} => {r[1]}");
                TryReplace(InputString, r[0], r[1]);
            }

            Console.WriteLine($"Answer is {Variants.Count}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day19.txt");

            Parse(data);

            var tokenLine = data[data.Length - 1];

            var tokens = new List<string>();
            var i = 0;
            while (i < tokenLine.Length)
            {
                if (i < tokenLine.Length - 1 && char.IsLower(tokenLine[i+1]))
                {
                    tokens.Add(tokenLine.Substring(i, 2));
                    i += 2;
                }
                else
                {
                    tokens.Add(tokenLine.Substring(i, 1));
                    i++;
                }
            }

            var countTotal = tokens.Count();
            var countRn = tokens.Count(x => x == "Rn");
            var countAr = tokens.Count(x => x == "Ar");
            var countY = tokens.Count(x => x == "Y");

            Console.WriteLine($"Tokens: {countTotal} Rn: {countRn} Ar: {countAr} Y: {countY}");

            // Sanity check
            if (countRn != countAr)
            {
                Console.WriteLine("Rn is not equal to Ar!");
                return;
            }

            Console.WriteLine($"Answer is {countTotal - countRn - countAr - 2*countY - 1}");
        }
    }
}
