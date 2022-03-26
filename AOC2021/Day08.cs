using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace AOC2021
{
    public class Day08 : DayOf2021
    {
        public override int Date => 8;
        public override string Name => "Seven Segment Search";
        public override object SolvePart1()
        {
            var outputParts = Input.Select(line => line.Split('|')[1].Trim().Split(' '));
            return outputParts.SelectMany(s=>s).Count(i => i.Length is 2 or 3 or 4 or 7);
        }

 

        public override object SolvePart2()
        {
            int sumValues = 0;
            //TestInput = new[] {@"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"};
            //TestInput = new[] { @"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe" };
            //UseTestInput = true;
            foreach (var line in Input)
            {
                var inputPart = line.Split('|')[0].Trim();
                var outputParts = line.Split('|')[1].Trim().Split(' ');
                var display = DeduceSegments(inputPart);

                int exponent = 0;
                sumValues += outputParts.Reverse().Sum(part => display.Decode(part) * (int) Math.Pow(10, exponent++));
            }

            return sumValues;
        }

        private SevenSegmentDisplay DeduceSegments(string inputPart)
        {
            //  AAAA
            // B    C
            // B    C
            //  DDDD
            // E    F
            // E    F
            //  GGGG

            var inputSets = inputPart.Split(' ').Select(s => new HashSet<char>(s)).ToArray();
            var one = inputSets.First(set => set.Count == 2);
            //var seven = inputSets.First(set => set.Count == 3);
            var four = inputSets.First(set => set.Count == 4);
            var eight = inputSets.First(set => set.Count == 7);
            var lengthFives = inputSets.Where(set => set.Count == 5).ToArray();
            //var segmentA = seven.Except(one);
            //var lengthFiveIntersects = lengthFives[0].Intersect(lengthFives[1]).Intersect(lengthFives[2]);
            var segmentD = lengthFives[0].Intersect(lengthFives[1]).Intersect(lengthFives[2]).Intersect(four);
            //var segmentG = lengthFiveIntersects.Except(segmentA).Except(segmentD);
            var segmentB = four.Except(one).Except(segmentD);
            var five = lengthFives.First(lf => lf.Intersect(segmentB).Any());
            var segmentE = eight.Except(five.Union(one));
            var segmentC = one.Except(five.Intersect(one));

            //var segmentF = five.Intersect(one);

            return new SevenSegmentDisplay(
                segmentB.First(),
                segmentC.First(),
                segmentD.First(),
                segmentE.First());
        }
        private class SevenSegmentDisplay
        {
            public char B, C, D, E;

            //  AAAA
            // B    C
            // B    C
            //  DDDD
            // E    F
            // E    F
            //  GGGG

            public SevenSegmentDisplay(char B, char C, char D, char E)
            {
                this.B = B;
                this.C = C;
                this.D = D;
                this.E = E;
            }

            public int Decode(string word)
            {
                return word.Length switch
                {
                    2 => 1,
                    3 => 7,
                    4 => 4,
                    7 => 8,
                    5 when word.Contains(B) => 5,
                    5 when word.Contains(E) => 2,
                    5 => 3,
                    6 when !word.Contains(D) => 0,
                    6 when !word.Contains(C) => 6,
                    6 => 9,
                    _ => throw new MagicSmokeException("Number unheard of :/")
                };
            }
        }
    }
}
