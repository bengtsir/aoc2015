using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Day11
    {
        bool IsValid(char[] s)
        {
            bool found;

            found = false;
            for (int i = 2; i < s.Length; i++)
            {
                if (s[i-2] == s[i] - 2 && s[i-1] == s[i] - 1)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                return false;
            }

            if (s.Contains('i') || s.Contains('o') || s.Contains('l'))
            {
                return false;
            }

            found = false;

            for (int i = 0; i < s.Length - 3 && !found; i++)
            {
                if (s[i] == s[i+1])
                {
                    for (int j = i + 2; j < s.Length - 1; j++)
                    {
                        if (s[j] == s[j+1] && s[j] != s[i])
                        {
                            found = true;
                            break;
                        }
                    }
                }
            }

            if (!found)
            {
                return false;
            }

            return true;
        }

        char[] Increment(char[] s)
        {
            s[s.Length - 1]++;

            while ("iol".Contains(s[s.Length-1]))
            {
                s[s.Length - 1]++;
            }

            if (s[s.Length - 1] > 'z')
            {
                var r = Increment(s.Take(s.Length - 1).ToArray()).ToList();
                r.Add('a');
                return r.ToArray();
            }

            return s;
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day11.txt");

            var pass = data[0].Select(c => c).ToArray();

            var newPass = Increment(pass);
            pass = newPass;
            while (!IsValid(newPass))
            {
                newPass = Increment(pass);
                pass = newPass;
            }

            Console.WriteLine($"Answer is {new string(pass)}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day11.txt");

            var pass = data[0].Select(c => c).ToArray();

            var newPass = Increment(pass);
            pass = newPass;
            while (!IsValid(newPass))
            {
                newPass = Increment(pass);
                pass = newPass;
            }

            newPass = Increment(pass);
            pass = newPass;
            while (!IsValid(newPass))
            {
                newPass = Increment(pass);
                pass = newPass;
            }

            Console.WriteLine($"Answer is {new string(pass)}");
        }
    }
}
