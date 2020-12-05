using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using CommonShared;


namespace AOC2020
{
    public class Day05 : Day
    {
        public override int Date => 5;

        public override string Name => "Binary Boarding";

        private List<int> BoardingPasses;

        public override object SolvePart1() => BoardingPasses.Max();

        public override object SolvePart2() => Enumerable.Range(BoardingPasses.Min(), BoardingPasses.Max() - BoardingPasses.Min() + 1).Except(BoardingPasses).Single();

        internal override void Prepare()
        {
            BoardingPasses = Input.Select(boardingPass => FindSeatId(boardingPass)).ToList();
        }

        private static (int Lo, int Hi) FindNextSplit(string p, (int Lo, int Hi) bounds)
        {
            p = p.Replace('L', 'F').Replace('R', 'B');
            int mid = ((bounds.Hi - bounds.Lo) >> 1) + bounds.Lo;
            return p switch
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
