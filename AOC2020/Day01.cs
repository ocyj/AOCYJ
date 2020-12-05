using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using CommonShared;

namespace AOC2020
{
    class Day01 : Day
    {
        private int[] _parsedInput;
        private IEnumerable<Pair<int>> _allPairs;

        public override int Date => 1;

        public override string Name => "Report Repair";

        public override object SolvePart1()
        {
            _parsedInput = Input.Select(l => int.Parse(l)).ToArray();
            _allPairs = _parsedInput.Pairs();
            var winningPair = _allPairs.Where(p => p.Value1 + p.Value2 == 2020).FirstOrDefault();
            return winningPair.Value1 * winningPair.Value2;
        }

        public override object SolvePart2()
        {
            throw new NotImplementedException();
        }
    }
}
