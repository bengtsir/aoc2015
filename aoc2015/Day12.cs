using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day12
    {
        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day12.txt");

            var s = data[0];

            int p1 = 0;
            int p2 = 0;

            int sum = 0;

            while (p1 < s.Length)
            {
                if (s[p1] == '-' || Char.IsDigit(s[p1]))
                {
                    p2 = p1 + 1;
                    while (p2 < s.Length && Char.IsDigit(s[p2]))
                    {
                        p2++;
                    }
                    if (p1+1 == p2 && s[p1] == '-')
                    {
                        throw new Exception("Single minus/dash");
                    }

                    var d = Int32.Parse(s.Substring(p1, p2-p1));
                    sum += d;

                    p1 = p2;
                }
                else
                {
                    p1++;
                }
            }

            Console.WriteLine($"Answer is {sum}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day12.txt");

            var values = data.Select(s => s.Select(c => c).ToArray()).ToArray();

            Console.WriteLine($"Answer is {42}");
        }
    }
}
