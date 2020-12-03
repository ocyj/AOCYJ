using Common;
using System;
using System.Linq;

namespace AOC2020
{
    public class Day03 : Day
    {
        public override int Date => 3;

        public override string Name => "Toboggan Trajectory";

        public override object SolvePart1()
        {
            //UseTestInput = true;
            return FindNumberOfTrees(1, 3);
        }

        public override object SolvePart2()
        {
            return FindNumberOfTrees(1, 1)
                    * FindNumberOfTrees(1, 3)
                    * FindNumberOfTrees(1, 5)
                    * FindNumberOfTrees(1, 7)
                    * FindNumberOfTrees(2, 1);
        }

        private long FindNumberOfTrees(int down, int right)
        {
            int column = 0;
            long count = 0;
            int mapWidth = Input[0].Length;

            for (int line = 0; line < Input.Length; line += down)
            {
                count += Input[line][column] == '#' ? 1 : 0;
                column += right;
                column %= mapWidth;
            }

            return count;
        }
    }
}
