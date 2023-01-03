using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day4
    {
        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day4.txt").First();
            var md5 = MD5.Create();

            //data = "abcdef";
            //data = "pqrstuv";

            var rest = 0;

            while (true)
            {
                rest++;
                var s = $"{data}{rest}";

                var h = md5.ComputeHash(s.Select(c => (byte)c).ToArray());
                if (h[0] == 0 && h[1] == 0 && (h[2] & 0xf0) == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Answer is {rest}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day4.txt").First();
            var md5 = MD5.Create();

            //data = "abcdef";
            //data = "pqrstuv";

            var rest = 0;

            while (true)
            {
                rest++;
                var s = $"{data}{rest}";

                var h = md5.ComputeHash(s.Select(c => (byte)c).ToArray());
                if (h[0] == 0 && h[1] == 0 && h[2] == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Answer is {rest}");
        }
    }
}
