using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 6)]
    public class Day06 : Day
    {
        public override string Name => "Custom Customs";

        public Day06(string[] input) : base(input) { }

        public override object SolvePart1() =>
            InputGroups.Select(l => l.SelectMany(c => c).Distinct()).Sum(s => s.Count());

        public override object SolvePart2()
        {
            return InputGroups.Sum(group =>
              group.Select(s => s.ToCharArray())
              .Aggregate(Enumerable.Range('a', 'a' + 'z' + 1).Select(i => (char)i),
                         (prev, next) => prev.Intersect(next), last => last.Count()));
        }

    }
}
