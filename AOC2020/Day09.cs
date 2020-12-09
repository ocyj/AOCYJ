using Common;
using CommonShared;
using System.Collections.Generic;
using System.Linq;

namespace AOC2020
{
    public class Day09 : Day
    {
        private long FirstInvalidNumber;
        private List<long> InputNumbers;
        private readonly int PreambleLength = 25;
        public override int Date => 9;

        public override string Name => "Encoding Error";

        public override object SolvePart1()
        {
            int currentIdx = PreambleLength;

            while (InputNumbers.GetRange(currentIdx - PreambleLength, PreambleLength)
                .Pairs().Any(p => p.Value1 != p.Value2 && p.Value1 + p.Value2 == InputNumbers[currentIdx]))
            {
                currentIdx++;
            }

            return FirstInvalidNumber = InputNumbers[currentIdx];
        }

        public override object SolvePart2()
        {
            List<long> candidateRange = new List<long>() { 0 };

            for (int rangeLength = 2; rangeLength < InputNumbers.Count; rangeLength++)
            {
                candidateRange = InputNumbers.ContiguousRanges(rangeLength)
                  .FirstOrDefault(r => r.Sum() == FirstInvalidNumber)?.ToList();
                if (candidateRange != null)
                {
                    break;
                }
            }

            return candidateRange.Min() + candidateRange.Max();
        }

        internal override void Prepare()
        {
            InputNumbers = Input.Select(n => long.Parse(n)).ToList();
        }
    }
}
