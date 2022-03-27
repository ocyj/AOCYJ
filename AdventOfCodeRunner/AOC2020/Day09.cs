using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 9)]
    public class Day09 : Day
    {
        private long _firstInvalidNumber;
        private readonly List<long> _inputNumbers;
        private readonly int _preambleLength = 25;

        public override string Name => "Encoding Error";
        public Day09(string[] input) : base(input)
        {
            _inputNumbers = Input.Select(n => long.Parse(n)).ToList();
        }
        public override object SolvePart1()
        {
            int currentIdx = _preambleLength;

            while (Extensions.Pairs(_inputNumbers.GetRange(currentIdx - _preambleLength, _preambleLength)).Any(p => p.Value1 != p.Value2 && p.Value1 + p.Value2 == _inputNumbers[currentIdx]))
            {
                currentIdx++;
            }

            return _firstInvalidNumber = _inputNumbers[currentIdx];
        }

        public override object SolvePart2()
        {
            List<long> candidateRange = new List<long>() { 0 };

            for (int rangeLength = 2; rangeLength < _inputNumbers.Count; rangeLength++)
            {
                candidateRange = _inputNumbers.ContiguousRanges(rangeLength)
                  .FirstOrDefault(r => r.Sum() == _firstInvalidNumber)?.ToList();
                if (candidateRange != null)
                {
                    break;
                }
            }
            return candidateRange.Min() + candidateRange.Max();
        }
    }
}
