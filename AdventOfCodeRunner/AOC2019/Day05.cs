using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCodeRunner.Common;
using AdventOfCodeRunner.AOC2019.D05;

namespace AdventOfCodeRunner.AOC2019
{
    [AdventOfCode(Year = 2019, Day = 5)]
    internal class Day05 : Day
    {
        public Day05(string[] input) : base(input) { }

        public override string Name => "Sunny with a Chance of Asteroids";

        public override object SolvePart1()
        {
            var memory = Input[0].Split(',').Select(s => int.Parse(s.Trim())).ToArray();
            var outputs = new List<int>();
            var computer = new IntCodeComputer(memory)
            {
                ReadInput = () => Task.FromResult(1),
                WriteOutput = v => outputs.Add(v)
            };
            computer.RunToCompletion().Wait();

            bool noErrors = true;
            foreach(var output in outputs.SkipLast(1))
            {
                noErrors &= output == 0;
            }

            string errors = noErrors ? "no errors!" : "errors!";

            return $"Computer output: {outputs[^1]} with {errors}";
        }

        public override object SolvePart2()
        {
            var memory = Input[0].Split(',').Select(s => int.Parse(s.Trim())).ToArray();
            var outputs = new List<int>();
            var computer = new IntCodeComputer(memory)
            {
                ReadInput = () => Task.FromResult(5),
                WriteOutput = v => outputs.Add(v)
            };
            computer.RunToCompletion().Wait();

            bool noErrors = true;
            foreach (var output in outputs.SkipLast(1))
            {
                noErrors &= output == 0;
            }

            string errors = noErrors ? "no errors!" : "errors!";

            return $"Computer output: {outputs[^1]} with {errors}";
        }
    }
}
