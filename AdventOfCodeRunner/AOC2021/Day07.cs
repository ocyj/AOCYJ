using System;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2021
{
    [AdventOfCode(Year = 2021, Day = 7)]
    internal class Day07 : Day
    {
        public override string Name => "The Treachery of Whales";

        private int[] _crabPositions;

        public Day07(string[] input) : base(input) { }

        public override object SolvePart1()
        {
            TestInput = new[] {@"16,1,2,0,4,2,7,1,2,14"};
            
            _crabPositions = Input[0].Split(',').Select(int.Parse).ToArray();
            long fuel = long.MaxValue;
            foreach (var position in Enumerable.Range(1, _crabPositions.Max()))
            {
                fuel = Math.Min( fuel, _crabPositions.Sum(crab => Math.Abs(crab - position)));
            }

            return fuel;
        }

        public override object SolvePart2()
        {
            long fuel = long.MaxValue;
            foreach (var position in Enumerable.Range(1, _crabPositions.Max()))
            {
                fuel = Math.Min(fuel, _crabPositions.Sum(crab => SumUpTo(Math.Abs(crab - position))));
            }

            return fuel;
        }

        private static int SumUpTo(int n) => n * (n + 1) / 2;
    }
}
