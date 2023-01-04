using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day8
    {
        internal string Parse(string s)
        {
            var s2 = "";
            int p = 1;

            while (p < s.Length - 1)
            {
                if (s[p] == '\\')
                {
                    p++;

                    if (s[p] == '\\')
                    {
                        s2 += '\\';
                    }
                    else if (s[p] == '"')
                    {
                        s2 += '"';
                    }
                    else if (s[p] == 'x')
                    {
                        p++;
                        s2 += (char)(Convert.ToInt32(s.Substring(p, 2), 16));
                        p++;
                    }
                    else
                    {
                        throw new Exception($"Invalid escape: {s[p]}");
                    }
                }
                else
                {
                    s2 += s[p];
                }
                p++;
            }

            return s2;
        }

        internal string Encode(string s)
        {
            var s2 = "\"";
            int p = 0;

            while (p < s.Length)
            {
                if (s[p] == '\\')
                {
                    s2 += "\\\\";
                }
                else if (s[p] == '"')
                {
                    s2 += "\\\"";
                }
                else
                {
                    s2 += s[p];
                }
                p++;
            }

            s2 += '"';

            return s2;
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day8.txt");

            Console.WriteLine($"Answer is {data.Sum(s => s.Length - Parse(s).Length)}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day8.txt");

            Console.WriteLine($"Answer is {data.Sum(s => Encode(s).Length - s.Length)}");
        }
    }
}
