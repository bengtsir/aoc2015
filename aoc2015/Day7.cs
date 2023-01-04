using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Op7
    {
        public string Name { get; set; }

        public string Operator { get; set; }

        public int ConstValue { get; set; }

        public Op7 LeftOp { get; set; }

        public Op7 RightOp { get; set; }

        internal bool Calculated { get; set; } = false;

        internal int CalculatedValue { get; set; }

        public Op7()
        {
            // Nothing
        }

        public Op7(string name)
        {
            Name = name;
        }

        public int Calculate()
        {
            int val;

            if (Calculated)
            {
                return CalculatedValue;
            }

            switch (Operator)
            {
                case "":
                    val = ConstValue;
                    break;

                case "CONST":
                    val = LeftOp.Calculate() & 0xffff;
                    break;

                case "NOT":
                    val = (~LeftOp.Calculate()) & 0xffff;
                    break;

                case "LSHIFT":
                    val = (LeftOp.Calculate() << RightOp.Calculate()) & 0xffff;
                    break;

                case "RSHIFT":
                    val = (LeftOp.Calculate() >> RightOp.Calculate()) & 0xffff;
                    break;

                case "AND":
                    val = (LeftOp.Calculate() & RightOp.Calculate()) & 0xffff;
                    break;

                case "OR":
                    val = (LeftOp.Calculate() | RightOp.Calculate()) & 0xffff;
                    break;

                default:
                    throw new Exception($"Invalid op: {Operator}");
            }

            Calculated = true;
            CalculatedValue = val;

            return CalculatedValue;
        }
    }

    internal class Day7
    {
        public Dictionary<string, Op7> Operations = new Dictionary<string, Op7>();

        public Op7 GetOp(string name)
        {
            if (!Operations.ContainsKey(name))
            {
                var op = new Op7(name);

                if (name.All(Char.IsDigit))
                {
                    op.Operator = "";
                    op.ConstValue = Int32.Parse(name);
                }

                Operations[name] = op;
            }

            return Operations[name];
        }

        public void Parse(string[] operations)
        {
            foreach (var op in operations)
            {
                var w = op.Split(' ');
                Op7 c;

                switch (w.Length)
                {
                    case 5:
                        // a op b -> c
                        c = GetOp(w[4]);
                        c.Operator = w[1];
                        c.LeftOp = GetOp(w[0]);
                        c.RightOp = GetOp(w[2]);

                        break;
                    case 4:
                        // op b -> c
                        c = GetOp(w[3]);
                        c.Operator = w[0];
                        c.LeftOp = GetOp(w[1]);

                        break;
                    case 3:
                        // a -> c
                        c = GetOp(w[2]);

                        c.Operator = "CONST";

                        c.LeftOp = GetOp(w[0]);

                        break;
                }
            }
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day7.txt");

            /*
            var data = new string[]
            {
                "123 -> x",
                "456 -> y",
                "x AND y -> d",
                "x OR y -> e",
                "x LSHIFT 2 -> f",
                "y RSHIFT 2 -> g",
                "NOT x -> h",
                "NOT y -> i",
            };
            */

            Parse(data);

            /*
            foreach (var node in new string[] {"d","e","f","g","h","i","x","y"})
            {
                Console.WriteLine($"Node {node} is {Operations[node].Calculate()}");
            }
            */

            Console.WriteLine($"Answer is {Operations["a"].Calculate()}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day7.txt");

            Parse(data);

            // Override 'b'
            Operations["b"].Operator = "CONST";
            Operations["b"].LeftOp = GetOp("16076");

            Console.WriteLine($"Answer is {Operations["a"].Calculate()}");
        }
    }
}
