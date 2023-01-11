using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day17
    {
        internal int Combinations = 0;
        internal int MinContainers = 999999;
        internal int MinCombinations = 0;

        void FindCombos(List<int> capacities, int volume, int containers)
        {
            if (volume < 0)
            {
                return;
            }

            if (volume == 0)
            {
                Combinations++;

                if (containers < MinContainers)
                {
                    MinContainers = containers;
                    MinCombinations = 0;
                }

                if (containers == MinContainers)
                {
                    MinCombinations++;
                }

                return;
            }

            if (capacities.Sum() < volume)
            {
                return;
            }

            var head = capacities.First();

            FindCombos(capacities.Skip(1).ToList(), volume, containers);
            FindCombos(capacities.Skip(1).ToList(), volume - head, containers + 1);
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day17.txt");

            var values = data.Select(s => Int32.Parse(s)).ToList();

            FindCombos(values, 150, 0);

            Console.WriteLine($"Answer is {Combinations}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day17.txt");

            var values = data.Select(s => Int32.Parse(s)).ToList();

            FindCombos(values, 150, 0);

            Console.WriteLine($"Answer is {MinContainers} containers with {MinCombinations} variations");
        }
    }
}
