using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 1)]
    class Day01 : Day
    {
        private readonly IEnumerable<Pair<int>> _allPairs;

        public Day01(string[] input) : base(input)
        {
            int[] parsedInput = Input.Select(int.Parse).ToArray();
            _allPairs = parsedInput.Pairs();
        }

        public override string Name => "Report Repair";

        public override object SolvePart1()
        {
            var winningPair = _allPairs.FirstOrDefault(p => p.Value1 + p.Value2 == 2020);
            return winningPair.Value1 * winningPair.Value2;
        }

        public override object SolvePart2()
        {
            throw new NotImplementedException();
        }
    }
}
