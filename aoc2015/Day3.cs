using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aoc2015.Structs;

namespace aoc2015
{
    internal class Day3
    {
        internal List<Point> Houses = new List<Point>();

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day3.txt");

            /*
            var data = new string[]
            {
                ">",
                "^>v<",
                "^v^v^v^v^v",
            };
            */

            foreach (var set in data)
            {
                Houses = new List<Point>();
                var currentHouse = new Point(0, 0);
                Houses.Add(currentHouse.Copy());

                foreach (var c in set)
                {
                    switch (c)
                    {
                        case '>':
                            currentHouse.Offset(1, 0);
                            break;
                        case '<':
                            currentHouse.Offset(-1, 0);
                            break;
                        case '^':
                            currentHouse.Offset(0, -1);
                            break;
                        case 'v':
                            currentHouse.Offset(0, 1);
                            break;
                    }

                    if (Houses.All(h => !h.Equals(currentHouse)))
                    {
                        Houses.Add(currentHouse.Copy());
                    }
                }

                Console.WriteLine($"Answer is {Houses.Count}");
            }

        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day3.txt");

            /*
            var data = new string[]
            {
                "^v",
                "^>v<",
                "^v^v^v^v^v",
            };
            */

            foreach (var set in data)
            {
                Houses = new List<Point>();

                var santaHouse = new Point(0, 0);
                var roboHouse = new Point(0, 0);

                bool santaMove = true;

                Houses.Add(santaHouse.Copy());

                foreach (var c in set)
                {
                    switch (c)
                    {
                        case '>':
                            if (santaMove)
                            {
                                santaHouse.Offset(1, 0);
                            }
                            else
                            {
                                roboHouse.Offset(1, 0);
                            }
                            break;
                        case '<':
                            if (santaMove)
                            {
                                santaHouse.Offset(-1, 0);
                            }
                            else
                            {
                                roboHouse.Offset(-1, 0);
                            }
                            break;
                        case '^':
                            if (santaMove)
                            {
                                santaHouse.Offset(0, -1);
                            }
                            else
                            {
                                roboHouse.Offset(0, -1);
                            }
                            break;
                        case 'v':
                            if (santaMove)
                            {
                                santaHouse.Offset(0, 1);
                            }
                            else
                            {
                                roboHouse.Offset(0, 1);
                            }
                            break;
                    }

                    if (santaMove)
                    {
                        if (Houses.All(h => !h.Equals(santaHouse)))
                        {
                            Houses.Add(santaHouse.Copy());
                        }
                    }
                    else
                    {
                        if (Houses.All(h => !h.Equals(roboHouse)))
                        {
                            Houses.Add(roboHouse.Copy());
                        }
                    }

                    santaMove = !santaMove;
                }

                Console.WriteLine($"Answer is {Houses.Count}");
            }
        }
    }
}
