using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 05)]
    public class Day05 : Day
    {
        public override string Name => "Binary Boarding";

        private readonly List<int> _boardingPasses;

        public Day05(string[] input) : base(input)
        {
            _boardingPasses = Input.Select(boardingPass => FindSeatId(boardingPass)).ToList();
        }

        public override object SolvePart1() => _boardingPasses.Max();

        public override object SolvePart2() =>
            Enumerable.Range(_boardingPasses.Min(), _boardingPasses.Max() - _boardingPasses.Min() + 1)
            .Except(_boardingPasses).Single();

        private static (int Lo, int Hi) FindNextSplit(string splitChoice, (int Lo, int Hi) bounds)
        {
            splitChoice = splitChoice.Replace('L', 'F').Replace('R', 'B');
            int mid = ((bounds.Hi - bounds.Lo) >> 1) + bounds.Lo;
            return splitChoice switch
            {
                "F" => (bounds.Lo, mid),
                "B" => (mid + 1, bounds.Hi),
                _ => throw new MagicSmokeException()
            };
        }

        private static int FindSeatId(string boardingPass)
        {
            var row = boardingPass[..^3].Aggregate((Lo: 0, Hi: 127), (bounds, split) => FindNextSplit(split.ToString(), bounds), last => last.Lo);
            var col = boardingPass[^3..].Aggregate((Lo: 0, Hi: 7), (bounds, split) => FindNextSplit(split.ToString(), bounds), last => last.Lo);
            return row * 8 + col;
        }
    }
}
