using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day9
    {
        internal Dictionary<string, int> Distances = new Dictionary<string, int>();
        internal List<string> Cities = new List<string>();

        void Parse(string[] data)
        {
            foreach (var s in data)
            {
                var m = s.Split(' ');

                if (!Cities.Contains(m[0]))
                {
                    Cities.Add(m[0]);
                }
                if (!Cities.Contains(m[2]))
                {
                    Cities.Add(m[2]);
                }

                var cost = Int32.Parse(m[4]);

                Distances[$"{m[0]}-{m[2]}"] = cost;
                Distances[$"{m[2]}-{m[0]}"] = cost;
            }
        }

        internal IEnumerable<List<string>> Permutations(List<string> head, List<string> tail)
        {
            if (tail.Count == 0)
            {
                yield return head;
            }
            else
            {
                foreach (var s in tail)
                {
                    var newHead = head.Select(h => h).ToList();
                    newHead.Add(s);

                    var newTail = tail.Where(t => t != s).ToList();

                    foreach (var p in Permutations(newHead, newTail))
                    {
                        yield return p;
                    }
                }
            }
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day9.txt");

            Parse(data);

            var cost = 99999999;
            var cheapestPath = new List<string>();

            foreach (var path in Permutations(new List<string>(), Cities.Select(c => c).ToList()))
            {
                var newCost = 0;

                for (int i = 1; i < path.Count; i++)
                {
                    newCost += Distances[$"{path[i - 1]}-{path[i]}"];
                }
                if (newCost < cost)
                {
                    cost = newCost;
                    Console.WriteLine($"Found new cheapest path with value {cost}");
                    Console.WriteLine($"{String.Join("-", path.ToArray())}");
                    cheapestPath = path.Select(c => c).ToList();
                }
            }

            Console.WriteLine($"Answer is {cost}");
            Console.WriteLine($"{String.Join("-", cheapestPath.ToArray())}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day9.txt");

            Parse(data);

            var cost = 0;
            var bestPath = new List<string>();

            foreach (var path in Permutations(new List<string>(), Cities.Select(c => c).ToList()))
            {
                var newCost = 0;

                for (int i = 1; i < path.Count; i++)
                {
                    newCost += Distances[$"{path[i - 1]}-{path[i]}"];
                }
                if (newCost > cost)
                {
                    cost = newCost;
                    Console.WriteLine($"Found new best path with value {cost}");
                    Console.WriteLine($"{String.Join("-", path.ToArray())}");
                    bestPath = path.Select(c => c).ToList();
                }
            }

            Console.WriteLine($"Answer is {cost}");
            Console.WriteLine($"{String.Join("-", bestPath.ToArray())}");
        }
    }
}
