using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Reindeer
    {
        public string Name { get; set; }

        public int Speed { get; set; }

        public int FlyTime { get; set; }

        public int RestTime { get; set; }

        public int LeaderPoints { get; set; } = 0;

        public long DistanceAfter(long time)
        {
            int stepDistance = FlyTime * Speed;
            long baseDist = (time / (FlyTime + RestTime)) * stepDistance;
            long restFlyTime = (time % (FlyTime + RestTime));
            if (restFlyTime > FlyTime)
            {
                restFlyTime = FlyTime;
            }

            return baseDist + (Speed * restFlyTime);
        }
    }

    internal class Day14
    {
        internal List<Reindeer> Reindeers = new List<Reindeer>();

        void Parse(string[] data)
        {
            foreach (var s in data)
            {
                var m = s.Split(' ');

                Reindeers.Add(new Reindeer()
                {
                    Name = m[0],
                    Speed = Int32.Parse(m[3]),
                    FlyTime = Int32.Parse(m[6]),
                    RestTime = Int32.Parse(m[13])
                });
            }
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day14.txt");

            Parse(data);

            var orderedReindeers = Reindeers.OrderByDescending(r => r.DistanceAfter(2503)).ToList();

            Console.WriteLine($"Answer is {orderedReindeers.First().Name} with {orderedReindeers.First().DistanceAfter(2503)} kilometers");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day14.txt");

            Parse(data);

            for (int i = 1; i <= 2503; i++)
            {
                var m = Reindeers.Max(r => r.DistanceAfter(i));
                foreach (var d in Reindeers.Where(r => r.DistanceAfter(i) == m))
                {
                    d.LeaderPoints++;
                }
            }

            var orderedReindeers = Reindeers.OrderByDescending(r => r.LeaderPoints).ToList();

            Console.WriteLine($"Answer is {orderedReindeers.First().Name} with {orderedReindeers.First().LeaderPoints} leader points");
        }
    }
}
