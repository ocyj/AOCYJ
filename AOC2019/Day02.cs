using System.Linq;
using CommonShared;

namespace AOC2019
{
    class Day02 : DayOf2019
    {
        public override int Date => 2;

        public override string Name => "1202 Program Alarm";

        int[] _parsedInput;

        public Day02() : base()
        {
            _parsedInput = Input[0].Split(',').Select(s => int.Parse(s)).ToArray();
        }

        public override object SolvePart1()
        {
            int[] memoryState = new int[_parsedInput.Length];
            _parsedInput.CopyTo(memoryState, 0);
            memoryState[1] = 12;
            memoryState[2] = 2;
            var computer = new D02.IntCodeComputer(memoryState);
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
                    var computer = new D02.IntCodeComputer(memoryState);
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
