using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 3)]
    internal class Day03 : Day
    {
        public override string Name => "Toboggan Trajectory";

        public Day03(string[] input) : base(input) { }

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
