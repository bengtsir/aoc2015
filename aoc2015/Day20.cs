using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day20
    {
        int NumberOfPresentsAtHouse(int house)
        {
            int count = 0;

            for (int i = 2; i <= house; i++)
            {
                if ((house % i) == 0)
                {
                    count += i;
                }
            }

            return (count + 1)*10; // Add in 10 for the first Elf
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day20.txt");

            var value = Int32.Parse(data[0]);

            var houses = new int[value];

            for (int i = 0; i < houses.Length; i++)
            {
                houses[i] = 1;
            }

            for (int i = 2; i < houses.Length; i++)
            {
                for (int j = i; j < houses.Length; j += i)
                {
                    houses[j] += i;
                }

                if (houses[i] * 10 >= value)
                {
                    Console.WriteLine($"Answer is {i}");
                    return;
                }
            }


            Console.WriteLine($"Answer is (undefined)");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day20.txt");

            var value = Int32.Parse(data[0]);

            var houses = new int[value];

            for (int i = 0; i < houses.Length; i++)
            {
                houses[i] = 0;
            }

            for (int i = 1; i < houses.Length + 1; i++)
            {
                var count = 0;
                for (int j = i; j < houses.Length && count < 50; j += i, count++)
                {
                    houses[j] += i;
                }

                if (houses[i] * 11 >= value)
                {
                    Console.WriteLine($"Answer is {i}");
                    return;
                }
            }


            Console.WriteLine($"Answer is (undefined)");
        }
    }
}
