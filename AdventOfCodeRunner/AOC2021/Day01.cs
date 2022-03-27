#nullable enable
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2021
{
    [AdventOfCode(Year = 2021, Day = 1)]
    internal class Day01 : Day
    {
        private List<int>? _inputList;

        public override string Name => "Sonar Sweep";

        public Day01(string[] input) : base(input) { }

        public override object SolvePart1()
        {
            _inputList = Input.Select(l => int.Parse(l)).ToList();
            return _inputList.SlidingWindows(2).Count(p => p.Skip(1).First() > p.First());
        }

        public override object SolvePart2()
        {
            var sliding3Windows = _inputList.SlidingWindows(3).ToList();
            var pairsOf3Windows = sliding3Windows.SlidingWindows(2).ToList();
            return pairsOf3Windows.Count(p => p.Skip(1).First().Sum() > p.First().Sum());
        }
    }
}