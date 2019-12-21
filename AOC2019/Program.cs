using Common;
using System;
using System.Linq;

namespace AOC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            var dagarTillDoppareDan = new Day[]
            {
                new Day01(),
                new Day02(),
                new Day03(),
                new Day04(),
                new Day05(),
                new Day06(),
                new Day07()
            };
            foreach (var day in dagarTillDoppareDan)
            {
                day.Solve();
            }
            Other();
        }

        private static void Other()
        {
        }
    }
}
