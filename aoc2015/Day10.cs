using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day10
    {
        internal string Iterate(string s)
        {
            StringBuilder res = new StringBuilder(s.Length * 2);
            int count;
            char c;
            int pos = 0;

            while (pos < s.Length)
            {
                c = s[pos];
                count = 1;
                pos++;

                while (pos < s.Length && s[pos] == c)
                {
                    count++;
                    pos++;
                }

                res.Append($"{count}{c}");
            }

            return res.ToString();
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day10.txt");

            var s = data[0];

            for (int i = 0; i < 40; i++)
            {
                var s2 = Iterate(s);
                Console.WriteLine($"{s2.Length}");
                s = s2;
            }

            Console.WriteLine($"Answer is {s.Length}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day10.txt");

            var b1 = new char[10000000];
            var b2 = new char[10000000];

            var b1length = 0;
            var b2length = 0;

            for (int i = 0; i < data[0].Length; i++)
            {
                b1[b1length++] = data[0][i];
            }

            var flipper = true;

            for (int i = 0; i < 50; i++)
            {
                if (flipper)
                {
                    int count;
                    char c;
                    int pos = 0;

                    b2length = 0;

                    while (pos < b1length)
                    {
                        c = b1[pos];
                        count = 1;
                        pos++;

                        while (pos < b1length && b1[pos] == c)
                        {
                            count++;
                            pos++;
                        }

                        b2[b2length++] = (char)('0' + count);
                        b2[b2length++] = c;
                    }
                }
                else
                {
                    int count;
                    char c;
                    int pos = 0;

                    b1length = 0;

                    while (pos < b2length)
                    {
                        c = b2[pos];
                        count = 1;
                        pos++;

                        while (pos < b2length && b2[pos] == c)
                        {
                            count++;
                            pos++;
                        }

                        b1[b1length++] = (char)('0' + count);
                        b1[b1length++] = c;
                    }
                }

                flipper = !flipper;
            }

            var answer = flipper ? b1length : b2length;

            Console.WriteLine($"Answer is {answer}");
        }
    }
}
