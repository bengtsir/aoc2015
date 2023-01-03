using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using aoc2015.Structs;

namespace aoc2015
{
    internal class Day6
    {
        private int[][] Board = new int[1000][];

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day6.txt");

            var re = new Regex(@"^(.*) ([\d]+,[\d]+) through ([\d]+,[\d]+)$");

            for (int i = 0; i < 1000; i++)
            {
                Board[i] = new int[1000];
            }

            foreach (var line in data)
            {
                var m = re.Match(line);

                var p1 = new Point(m.Groups[2].Value);
                var p2 = new Point(m.Groups[3].Value);

                switch (m.Groups[1].Value)
                {
                    case "turn on":
                        for (int i = p1.Y; i <= p2.Y; i++)
                        {
                            for (int j = p1.X; j <= p2.X; j++)
                            {
                                Board[i][j] = 1;
                            }
                        }

                        break;
                    case "turn off":
                        for (int i = p1.Y; i <= p2.Y; i++)
                        {
                            for (int j = p1.X; j <= p2.X; j++)
                            {
                                Board[i][j] = 0;
                            }
                        }

                        break;
                    case "toggle":
                        for (int i = p1.Y; i <= p2.Y; i++)
                        {
                            for (int j = p1.X; j <= p2.X; j++)
                            {
                                Board[i][j] = 1 - Board[i][j];
                            }
                        }

                        break;
                }
            }

            Console.WriteLine($"Answer is {Board.Sum(r => r.Sum())}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day6.txt");

            var re = new Regex(@"^(.*) ([\d]+,[\d]+) through ([\d]+,[\d]+)$");

            for (int i = 0; i < 1000; i++)
            {
                Board[i] = new int[1000];
            }

            foreach (var line in data)
            {
                var m = re.Match(line);

                var p1 = new Point(m.Groups[2].Value);
                var p2 = new Point(m.Groups[3].Value);

                switch (m.Groups[1].Value)
                {
                    case "turn on":
                        for (int i = p1.Y; i <= p2.Y; i++)
                        {
                            for (int j = p1.X; j <= p2.X; j++)
                            {
                                Board[i][j] += 1;
                            }
                        }

                        break;
                    case "turn off":
                        for (int i = p1.Y; i <= p2.Y; i++)
                        {
                            for (int j = p1.X; j <= p2.X; j++)
                            {
                                if (Board[i][j] > 0)
                                {
                                    Board[i][j] -= 1;
                                }
                            }
                        }

                        break;
                    case "toggle":
                        for (int i = p1.Y; i <= p2.Y; i++)
                        {
                            for (int j = p1.X; j <= p2.X; j++)
                            {
                                Board[i][j] += 2;
                            }
                        }

                        break;
                }
            }

            Console.WriteLine($"Answer is {Board.Sum(r => r.Sum())}");
        }
    }
}
