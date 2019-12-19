using Common;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019
{
    class Day05 : Day
    {
        public override int Date => 5;

        public override string Name => "Sunny with a Chance of Asteroids";

        public override object SolvePart1()
        {
            var memory = Input[0].Split(',').Select(s => int.Parse(s.Trim())).ToArray();
            var outputs = new List<int>();
            var computer = new IntCodeComputer(memory)
            {
                ReadInput = () => 1,
                WriteOutput = v => outputs.Add(v)
            };
            computer.RunToCompletion();

            return $"Computer output = {outputs[^1]}";
        }

        public override object SolvePart2()
        {
            return "";
        }
    }
}
