using CommonShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2020
{
    public class Day06 : Day
    {
        private List<HashSet<char>> CustomForms;

        public override int Date => 6;

        public override string Name => "Custom Customs";

        public override object SolvePart1() => CustomForms.Sum(cf => cf.Count);

        public override object SolvePart2()
        {
            throw new NotImplementedException();
        }

        internal override void Prepare()
        {
            UseTestInput = true;

            TestInput = @"abc

a
b
c

ab
ac

a
a
a
a

b".Split(Environment.NewLine);


         

        }
    }
}
