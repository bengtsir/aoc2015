using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day13
    {
        internal Dictionary<string, int> Happinesses = new Dictionary<string, int>();
        internal List<string> Guests = new List<string>();

        void Parse(string[] data)
        {
            foreach (var s in data)
            {
                var m = s.TrimEnd('.').Split(' ');

                if (!Guests.Contains(m[0]))
                {
                    Guests.Add(m[0]);
                }

                var cost = Int32.Parse(m[3]);
                if (m[2] == "lose")
                {
                    cost = -cost;
                }

                Happinesses[$"{m[0]}-{m[10]}"] = cost;
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
            var data = File.ReadAllLines(@"data\day13.txt");

            Parse(data);

            var happiness = -999999999;
            var bestSeating = new List<string>();

            foreach (var seating in Permutations(new List<string>(), Guests.Select(c => c).ToList()))
            {
                var newVal = 0;

                for (int i = 1; i < seating.Count; i++)
                {
                    newVal += Happinesses[$"{seating[i - 1]}-{seating[i]}"];
                    newVal += Happinesses[$"{seating[i]}-{seating[i - 1]}"];
                }
                newVal += Happinesses[$"{seating[0]}-{seating[seating.Count - 1]}"];
                newVal += Happinesses[$"{seating[seating.Count - 1]}-{seating[0]}"];

                if (newVal > happiness)
                {
                    happiness = newVal;
                    Console.WriteLine($"Found new best seating with value {happiness}");
                    Console.WriteLine($"{String.Join("-", seating.ToArray())}");
                    bestSeating = seating.Select(c => c).ToList();
                }
            }

            Console.WriteLine($"Answer is {happiness}");
            Console.WriteLine($"{String.Join("-", bestSeating.ToArray())}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day13.txt");

            Parse(data);

            var myName = "Self";

            foreach (var guest in Guests)
            {
                Happinesses[$"{guest}-{myName}"] = 0;
                Happinesses[$"{myName}-{guest}"] = 0;
            }

            Guests.Add(myName);

            var happiness = -999999999;
            var bestSeating = new List<string>();

            foreach (var seating in Permutations(new List<string>(), Guests.Select(c => c).ToList()))
            {
                var newVal = 0;

                for (int i = 1; i < seating.Count; i++)
                {
                    newVal += Happinesses[$"{seating[i - 1]}-{seating[i]}"];
                    newVal += Happinesses[$"{seating[i]}-{seating[i - 1]}"];
                }
                newVal += Happinesses[$"{seating[0]}-{seating[seating.Count - 1]}"];
                newVal += Happinesses[$"{seating[seating.Count - 1]}-{seating[0]}"];

                if (newVal > happiness)
                {
                    happiness = newVal;
                    Console.WriteLine($"Found new best seating with value {happiness}");
                    Console.WriteLine($"{String.Join("-", seating.ToArray())}");
                    bestSeating = seating.Select(c => c).ToList();
                }
            }

            Console.WriteLine($"Answer is {happiness}");
            Console.WriteLine($"{String.Join("-", bestSeating.ToArray())}");
        }
    }
}
