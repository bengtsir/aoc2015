using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day2
    {
        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day2.txt");

            var values = data.Select(s => s.Split('x').Select(v => Int32.Parse(v)).ToArray()).ToArray();

            var sides = values.Select(vv => new int[] { vv[0] * vv[1], vv[0]*vv[2], vv[1]*vv[2] }).ToArray();

            var paper = sides.Select(s => 2 * s[0] + 2 * s[1] + 2 * s[2] + s.Min()).Sum();

            Console.WriteLine($"Answer is {paper}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day2.txt");

            var values = data.Select(s => s.Split('x').Select(v => Int32.Parse(v)).ToArray()).ToArray();

            var stringLen = values.Select(vv => vv[0] * vv[1] * vv[2] + vv.OrderBy(v => v).Take(2).Sum() * 2).Sum();

            Console.WriteLine($"Answer is {stringLen}");
        }
    }
}
