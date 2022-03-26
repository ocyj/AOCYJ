using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day06 : DayOf2021
    {
        public override int Date => 6;
        public override string Name => "Lanternfish";
        public override object SolvePart1()
        {
            //UseTestInput = false;
            //TestInput = new[] { @"3,4,3,1,2" };

            //IEnumerable<int> lanternFishes = Input.First().Split(',').Select(f => int.Parse(f)).ToArray();
            //for (int day = 1; day <= 80; day++)
            //{
            //    var newFishes = lanternFishes.Count(f => f == 0);
            //    lanternFishes = lanternFishes.Select(f => f == 0 ? 6 : f - 1).Concat(Enumerable.Repeat(8, newFishes));
            //}

            //return lanternFishes.Count();
            return 0;
        }

        public override object SolvePart2()
        {
            // Test with one fish with an initial timer value of 3.
            // After 20 days we should have 5 fishes.
            Console.WriteLine();
            Func<int,int, long> f = (t, c) => 1 + BreedingLanternFishes(t, c);
            for (int i = 1; i <= 50; i++)
            {
                Console.WriteLine($"{i}\t{f(1,i)}\t{f(2, i)}\t{f(3, i)}\t{f(4, i)}\t{f(5, i)}");
            }


            //return 1 + BreedingLanternFishes(6, 256);

            return 0;
        }

        private static long BreedingLanternFishes(int timer, int countOfDays)
        {
            var nextCount = countOfDays - timer;
            if (nextCount > 0)
            {
                // return 1 child
                // + child's descendants (init = 8)
                // + all descendants of me (init = 6)

                return 1 + BreedingLanternFishes(8, nextCount - 1)
                         + BreedingLanternFishes(6, nextCount - 1);
            }
            return 0;
        }
    }
}
