using System.Linq;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2019
{
    [AdventOfCode(Year = 2019, Day = 2)]
    internal class Day02 : Day
    {
        public override string Name => "1202 Program Alarm";

        private readonly int[] _parsedInput;

        public Day02(string[] input) : base(input)
        {
            _parsedInput = Input[0].Split(',').Select(s => int.Parse(s)).ToArray();
        }

        public override object SolvePart1()
        {
            int[] memoryState = new int[_parsedInput.Length];
            _parsedInput.CopyTo(memoryState, 0);
            memoryState[1] = 12;
            memoryState[2] = 2;
            var computer = new global::AdventOfCodeRunner.AOC2019.D02.IntCodeComputer(memoryState);
            return computer.RunToEnd()[0];
        }

        public override object SolvePart2()
        {
            int magicNumber = 19690720;
            for (int noun = 0; noun < 100; noun++)
            {
                for(int verb=0; verb < 100; verb++)
                {
                    int[] memoryState = new int[_parsedInput.Length];
                    _parsedInput.CopyTo(memoryState, 0);
                    memoryState[1] = noun;
                    memoryState[2] = verb;
                    var computer = new global::AdventOfCodeRunner.AOC2019.D02.IntCodeComputer(memoryState);
                    int result = computer.RunToEnd()[0];
                    if (magicNumber == result)
                    {
                        return (noun * 100 + verb).ToString();
                    }
                }
            }
            return "<no solution found??>";
        }
    }
}
