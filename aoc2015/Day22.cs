using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day22
    {
        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day22.txt");

            var values = data.Select(s => s.Select(c => c).ToArray()).ToArray();

            Console.WriteLine($"Answer is {42}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day22.txt");

            var values = data.Select(s => s.Select(c => c).ToArray()).ToArray();

            Console.WriteLine($"Answer is {42}");
        }
    }
}
