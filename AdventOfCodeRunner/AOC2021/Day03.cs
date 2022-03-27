using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2021
{
    [AdventOfCode(Year = 2021, Day = 3)]
    public class Day03 : Day
    {
        public override string Name => "Binary Diagnostic";

        public Day03(string[] input) : base(input) { }

        public override object SolvePart1()
        {
            var counts = CountOnes(Input);
            var mostCommon = counts.Select(b => b >= Input.Length / 2 ? 1 : 0);
            var gamma = Convert.ToInt32(string.Join("", mostCommon),2);

            // Example (ints are 32 bits)         .....
            // gamma   00000000000000000000000000010110
            // ~gamma  11111111111111111111111111101001
            // &-mask  00000000000000000000000000011111
            // epsilon 00000000000000000000000000001001
            var epsilon = ~gamma & 0xff_ff_ff_ff>>(32 - Input.First().Length);

            return gamma * epsilon;
        }

        public override object SolvePart2()
        {
            var oxygenRating = GetRating((count, total) => count >= total - count ? '1' : '0');
            var co2Rating = GetRating((count, total) => count >= total - count ? '0' : '1');
            return oxygenRating * co2Rating;
        }

        private static IEnumerable<int> CountOnes(string[] lines, int? index=null)
        {
            var counts = index switch
            {
                null => new int[lines.First().Length],
                _ => new int[1]
            };

            foreach (var line in lines)
            {
                var value = line;
                if (index!=null)
                {
                    value = line.Substring(index.Value, 1);
                }
                // int value of char '1' is 49
                counts = value.Zip(counts, (val, count) => (val - 48) + count).ToArray();
            }
            return counts;
        }

        private int GetRating(Func<int,int, char> bitCriteria)
        {
            var candidates = Input.ToArray();
            int bitPosition = 0;
            while (candidates.Length > 1)
            {
                var count = CountOnes(candidates,bitPosition).First();
                char filterChar = bitCriteria(count, candidates.Length);
                candidates = candidates.Where(line => line[bitPosition] == filterChar).ToArray();
                bitPosition++;
            }
            return Convert.ToInt32(candidates.First(),2);
        }

    }
}
