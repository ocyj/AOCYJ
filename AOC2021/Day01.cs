using Common;

namespace AOC2021
{
    public class Day01 : DayOf2021
    {
        private List<int>? _inputList;
        public override int Date => 1;

        public override string Name => "Sonar Sweep";

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