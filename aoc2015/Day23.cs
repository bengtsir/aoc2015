using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day23
    {
        internal int Solve(List<string>[] values, bool isPart2)
        {
            int a = isPart2 ? 1 : 0;
            int b = 0;

            int pc = 0;
            int offset = 0;

            while (pc >= 0 && pc < values.Length)
            {
                switch (values[pc][0])
                {
                    case "hlf":
                        if (values[pc][1] == "a")
                        {
                            a /= 2;
                        }
                        else
                        {
                            b /= 2;
                        }
                        pc++;
                        break;
                    case "tpl":
                        if (values[pc][1] == "a")
                        {
                            a *= 3;
                        }
                        else
                        {
                            b *= 3;
                        }
                        pc++;
                        break;
                    case "inc":
                        if (values[pc][1] == "a")
                        {
                            a++;
                        }
                        else
                        {
                            b++;
                        }
                        pc++;
                        break;
                    case "jmp":
                        offset = Int32.Parse(values[pc][1]);
                        pc += offset;
                        break;
                    case "jie":
                        offset = Int32.Parse(values[pc][2]);
                        if (values[pc][1] == "a")
                        {
                            if ((a % 2) == 0)
                            {
                                pc += offset;
                            }
                            else
                            {
                                pc += 1;
                            }
                        }
                        else
                        {
                            if ((b % 2) == 0)
                            {
                                pc += offset;
                            }
                            else
                            {
                                pc += 1;
                            }
                        }
                        break;
                    case "jio":
                        offset = Int32.Parse(values[pc][2]);
                        if (values[pc][1] == "a")
                        {
                            if (a == 1)
                            {
                                pc += offset;
                            }
                            else
                            {
                                pc += 1;
                            }
                        }
                        else
                        {
                            if (b == 1)
                            {
                                pc += offset;
                            }
                            else
                            {
                                pc += 1;
                            }
                        }
                        break;
                }
            }

            return b;
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day23.txt");

            var values = data.Select(s => s.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToArray();

            Console.WriteLine($"Answer is {Solve(values, false)}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day23.txt");

            var values = data.Select(s => s.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList()).ToArray();

            Console.WriteLine($"Answer is {Solve(values, true)}");
        }
    }
}
