using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day5
    {
        internal bool IsNice(string s)
        {
            if (s.Count(c => "aeiou".Contains(c)) < 3)
            {
                return false;
            }

            bool found = false;

            for (int i = 1; i  < s.Length; i ++)
            {
                if (s[i] == s[i-1])
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false;
            }

            var booStrings = new string[]
            {
                "ab", "cd", "pq", "xy"
            };

            foreach (var boo in booStrings)
            {
                if (s.Contains(boo))
                {
                    return false;
                }
            }

            return true;
        }

        internal bool IsNice2(string s)
        {
            bool found = false;

            for (int i = 2; i < s.Length-1; i++)
            {
                for (int j = 0; j + i < s.Length-1; j++)
                {
                    if (s[i-2] == s[i+j] && s[i-1] == s[i+j+1])
                    {
                        found = true;
                    }
                }
            }

            if (!found)
            {
                return false;
            }

            found = false;

            for (int i = 2; i < s.Length; i++)
            {
                if (s[i-2] == s[i])
                {
                    found = true;
                }
            }

            return found;
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day5.txt");

            Console.WriteLine($"Answer is {data.Count(s => IsNice(s))}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day5.txt");

            /*
            var data = new string[]
            {
                "qjhvhtzxzqqjkmpb",
                "xxyxx",
                "uurcxstgmygtbstg",
                "ieodomkazucvgmuy",
            };
            */

            /*
            foreach (var s in data)
            {
                Console.WriteLine($"{s}: {IsNice2(s)}");
            }
            */

            Console.WriteLine($"Answer is {data.Count(s => IsNice2(s))}");
        }
    }
}
