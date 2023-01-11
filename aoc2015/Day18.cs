using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day18
    {
        private int[][] Board;

        void Parse(string[] data, bool part2 = false)
        {
            Board = new int[data.Length+2][];
            
            Board[0] = Enumerable.Repeat(0, data[0].Length + 2).ToArray();
            
            int r = 1;

            foreach (var s in data)
            {
                Board[r++] = ("." + s + ".").Select(c => c == '#' ? 1 : 0).ToArray();
            }

            Board[r] = Enumerable.Repeat(0, data[0].Length + 2).ToArray();

            if (part2)
            {
                Board[1][1] = 1;
                Board[1][Board[0].Length - 2] = 1;
                Board[Board.Length - 2][1] = 1;
                Board[Board.Length - 2][Board[0].Length - 2] = 1;
            }
        }

        public void Iterate(bool part2 = false)
        {
            for (int r = 1; r < Board.Length - 1; r++)
            {
                for (int k = 1; k < Board[1].Length - 1; k++)
                {
                    var sum = Board[r - 1][k - 1] + Board[r - 1][k] + Board[r - 1][k + 1]
                              + Board[r][k - 1] + Board[r][k + 1]
                              + Board[r + 1][k - 1] + Board[r + 1][k] + Board[r + 1][k + 1];
                    sum %= 100;
                    if (Board[r][k] == 1 && (sum == 2 || sum == 3))
                    {
                        Board[r][k] += 100;
                    }

                    if (Board[r][k] == 0 && sum == 3)
                    {
                        Board[r][k] += 100;
                    }
                }
            }

            for (int r = 1; r < Board.Length - 1; r++)
            {
                for (int k = 1; k < Board[1].Length - 1; k++)
                {
                    Board[r][k] /= 100;
                }
            }

            if (part2)
            {
                Board[1][1] = 1;
                Board[1][Board[0].Length - 2] = 1;
                Board[Board.Length - 2][1] = 1;
                Board[Board.Length - 2][Board[0].Length - 2] = 1;
            }
        }

        void PrintBoard()
        {
            foreach (var b in Board)
            {
                Console.WriteLine(new string(b.Select(i => i == 1 ? '#' : '.').ToArray()));
            }
            Console.WriteLine($"On: {Board.Sum(b => b.Sum())}");
            Console.WriteLine();
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day18.txt");

            Parse(data);

            for (int i = 0; i < 100; i++)
            {
                Iterate();
            }
            
            Console.WriteLine($"Answer is {Board.Sum(r => r.Sum())}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day18.txt");

            /*
            var data = new string[]
            {
                "##.#.#",
                "...##.",
                "#....#",
                "..#...",
                "#.#..#",
                "####.#",
            };
            */

            Parse(data, true);
            //PrintBoard();

            for (int i = 0; i < 100; i++)
            {
                Iterate(true);
                //PrintBoard();
            }

            Console.WriteLine($"Answer is {Board.Sum(r => r.Sum())}");
        }
    }
}
