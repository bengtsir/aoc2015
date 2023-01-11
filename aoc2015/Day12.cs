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
        int CountGroup(string s, ref int pos)
        {
            char ending;
            bool inObject = false;
            bool containsRed = false;
            int partSum = 0;

            if (s[pos] == '[')
            {
                ending = ']';
            }
            else if (s[pos] == '{')
            {
                ending = '}';
                inObject = true;
            }
            else
            {
                throw new Exception($"Invalid group start: {s[pos]}");
            }

            pos++;

            while (pos < s.Length && s[pos] != ending)
            {
                if (s[pos] == '-' || Char.IsDigit(s[pos]))
                {
                    var p2 = pos + 1;
                    while (p2 < s.Length && Char.IsDigit(s[p2]))
                    {
                        p2++;
                    }
                    if (pos + 1 == p2 && s[pos] == '-')
                    {
                        throw new Exception("Single minus/dash");
                    }

                    var d = Int32.Parse(s.Substring(pos, p2 - pos));
                    partSum += d;

                    pos = p2;
                }
                else if (inObject && s[pos] == ':')
                {
                    if (s.Substring(pos, 6) == ":\"red\"")
                    {
                        containsRed = true;
                        pos += 6;
                    }
                    else
                    {
                        pos++;
                    }
                }
                else if (s[pos] == '[' || s[pos] == '{')
                {
                    partSum += CountGroup(s, ref pos);
                }
                else
                {
                    pos++;
                }
            }

            if (pos >= s.Length)
            {
                throw new Exception($"Unbalanced group");
            }

            pos++;

            if (inObject && containsRed)
            {
                return 0;
            }
            else
            {
                return partSum;
            }
        }

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

            int pos = 0;

            Console.WriteLine($"Answer is {CountGroup(data[0], ref pos)}");
        }
    }
}
