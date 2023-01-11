using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    internal class Ingredient
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Durability { get; set; }

        public int Flavor { get; set; }

        public int Texture { get; set; }

        public int Calories { get; set; }
    }
 
    internal class Day15
    {
        internal Ingredient[] Ingredients;

        void Parse(string[] data)
        {
            Ingredients = new Ingredient[data.Length];
            var i = 0;

            foreach (var s in data)
            {
                var m = s.Split(' ');
                Ingredients[i++] = new Ingredient()
                {
                    Name = m[0].TrimEnd(':'),
                    Capacity   = Int32.Parse(m[2].TrimEnd(',')),
                    Durability = Int32.Parse(m[4].TrimEnd(',')),
                    Flavor     = Int32.Parse(m[6].TrimEnd(',')),
                    Texture    = Int32.Parse(m[8].TrimEnd(',')),
                    Calories   = Int32.Parse(m[10].TrimEnd(','))
                };
            }
        }

        public void Part1()
        {
            var data = File.ReadAllLines(@"data\day15.txt");

            Parse(data);

            int[] maxRecipe = { 0, 0, 0, 0 };
            long maxRecipeValue = 0;

            long[] sums = { 0, 0, 0, 0 };
            long currVal = 0;

            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine($"First loopval {i}");
                for (int j = i+1; j <= 100; j++)
                {
                    for (int k = j+1; k <= 100; k++)
                    {
                        for (int l = k+1; l <= 100; l++)
                        {
                            sums[0] = Ingredients[0].Capacity * i + Ingredients[1].Capacity * (j - i) + Ingredients[2].Capacity * (k - j) + Ingredients[3].Capacity * (l - k);
                            sums[1] = Ingredients[0].Durability * i + Ingredients[1].Durability * (j - i) + Ingredients[2].Durability * (k - j) + Ingredients[3].Durability * (l - k);
                            sums[2] = Ingredients[0].Flavor * i + Ingredients[1].Flavor * (j - i) + Ingredients[2].Flavor * (k - j) + Ingredients[3].Flavor * (l - k);
                            sums[3] = Ingredients[0].Texture * i + Ingredients[1].Texture * (j - i) + Ingredients[2].Texture * (k - j) + Ingredients[3].Texture * (l - k);

                            if (sums.All(s => s > 0))
                            {
                                currVal = sums[0] * sums[1] * sums[2] * sums[3];
                                if (currVal > maxRecipeValue)
                                {
                                    maxRecipe[0] = i;
                                    maxRecipe[1] = (j - i);
                                    maxRecipe[2] = (k - j);
                                    maxRecipe[3] = (l - k);
                                    maxRecipeValue = currVal;

                                    Console.WriteLine($"Found new max at ({i},{j-i},{k-j},{l-k}) with value {currVal}");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Answer is {maxRecipeValue}");
        }

        public void Part2()
        {
            var data = File.ReadAllLines(@"data\day15.txt");

            Parse(data);

            int[] maxRecipe = { 0, 0, 0, 0 };
            long maxRecipeValue = 0;

            long[] sums = { 0, 0, 0, 0 };
            long currVal = 0;
            int cals = 0;

            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine($"First loopval {i}");
                for (int j = i + 1; j <= 100; j++)
                {
                    for (int k = j + 1; k <= 100; k++)
                    {
                        for (int l = k + 1; l <= 100; l++)
                        {
                            sums[0] = Ingredients[0].Capacity * i + Ingredients[1].Capacity * (j - i) + Ingredients[2].Capacity * (k - j) + Ingredients[3].Capacity * (l - k);
                            sums[1] = Ingredients[0].Durability * i + Ingredients[1].Durability * (j - i) + Ingredients[2].Durability * (k - j) + Ingredients[3].Durability * (l - k);
                            sums[2] = Ingredients[0].Flavor * i + Ingredients[1].Flavor * (j - i) + Ingredients[2].Flavor * (k - j) + Ingredients[3].Flavor * (l - k);
                            sums[3] = Ingredients[0].Texture * i + Ingredients[1].Texture * (j - i) + Ingredients[2].Texture * (k - j) + Ingredients[3].Texture * (l - k);

                            cals = Ingredients[0].Calories * i + Ingredients[1].Calories * (j - i) + Ingredients[2].Calories * (k - j) + Ingredients[3].Calories * (l - k);

                            if (sums.All(s => s > 0) && cals == 500)
                            {
                                currVal = sums[0] * sums[1] * sums[2] * sums[3];
                                if (currVal > maxRecipeValue)
                                {
                                    maxRecipe[0] = i;
                                    maxRecipe[1] = (j - i);
                                    maxRecipe[2] = (k - j);
                                    maxRecipe[3] = (l - k);
                                    maxRecipeValue = currVal;

                                    Console.WriteLine($"Found new max at ({i},{j - i},{k - j},{l - k}) with value {currVal}");
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Answer is {maxRecipeValue}");
        }
    }
}
