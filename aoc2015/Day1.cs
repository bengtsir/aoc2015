using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day1
    {
        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day1.txt");

            var values = data.Select(s => s.Select(c => c).ToArray()).First();

            Console.WriteLine($@"Answer is {values.Count(c => c == '(') - values.Count(c => c == ')')}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day1.txt");

            var values = data.Select(s => s.Select(c => c).ToArray()).First();

            var pos = 0;
            var current = 0;

            foreach (var c in values)
            {
                pos++;
                switch (c)
                {
                    case '(':
                        current++;
                        break;
                    case ')':
                        current--;
                        break;
                }

                if (current < 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Answer is {pos}");
        }
    }
}
