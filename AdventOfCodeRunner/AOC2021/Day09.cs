using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2021
{
    [AdventOfCode(Year = 2021, Day = 9)]
    public class Day09 : Day
    {
        public override string Name => "Smoke Basin";

        private readonly int[,] _heightMap;

        public Day09(string[] input) : base(input)
        {
            TestInput =
@"2199943210
3987894921
9856789892
8767896789
9899965678".Split(Environment.NewLine);
            UseTestInput = false;

            _heightMap = new int[Input.Length, Input[0].Length];
            foreach (var (line, rowIdx) in Input.Select( (lineText, rowIdx)=> (lineText, rowIdx)))
            {
                foreach (var (value, colIdx) in line.Select((columnChar, colIdx) => (value: columnChar - 48, colIdx)))
                {
                    _heightMap[rowIdx, colIdx] = value;
                }
            }
        }
        public override object SolvePart1()
        {
            return VonNeumannNeighborhoods().Where(nbh => nbh.Skip(1).All(item => nbh.First().value < item.value))
                .Sum(minimum => minimum.First().value + 1);
        }

        public override object SolvePart2()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<IEnumerable<(int value, int row, int col)>> VonNeumannNeighborhoods()
        {
            int nRows = _heightMap.GetLength(0);
            int nCols = _heightMap.GetLength(1);

            for (int row = 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {

                    //               [(2) r-1, c]
                    // [(1) r, c-1]  [(0) r,   c]  [(3) r, c+1]
                    //               [(4) r+1, c]

                    var indices = (new[] { row, row, row - 1, row, row + 1 })
                        .Zip(new[] { col, col - 1, col, col + 1, col }).Where<(int r, int c)>(x =>
                              x.r.WithinRange(0, nRows, includeUpper: false) &&
                              x.c.WithinRange(0, nCols, includeUpper: false));
                    yield return indices.Select(x => (value: _heightMap[x.r, x.c], row: x.r, col: x.c));
                }
            }
        }
    }
}
