using CommonShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2020
{
    public class Day06 : DayOf2020
    {

        public override int Date => 6;

        public override string Name => "Custom Customs";

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
