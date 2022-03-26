using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021
{
    public class Day07 : DayOf2021
    {
        private int[] _crabPositions;
        public override int Date => 7;
        public override string Name => "The Treachery of Whales";
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

        private int SumUpTo(int n) => n * (n + 1) / 2;
    }
}
