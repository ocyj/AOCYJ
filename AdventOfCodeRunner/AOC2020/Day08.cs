using System;
using System.Collections.Generic;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2020
{
    [AdventOfCode(Year = 2020, Day = 8)]
    public class Day08 : Day
    {
        private readonly List<int> _swapableIndices;
        private Func<int, string> _inputSwapper(int swapNth)
        {
            if (swapNth == 0)
            {
                return index => Input[index];
            }
            else
            {
                return index =>
                {
                    if (index == _swapableIndices[swapNth - 1])
                    {

                        return Input[index][..3] switch
                        {
                            "jmp" => $"nop{Input[index][3..]}",
                            "nop" => $"jmp{Input[index][3..]}",
                            _ => throw new MagicSmokeException()
                        };
                    }
                    else
                    {
                        return Input[index];
                    }
                };
            }
        }

        public Day08(string[] input) : base(input)
        {
            _swapableIndices = new List<int>();
            for (int index = 0; index < Input.Length; index++)
            {
                string instruction = Input[index];
                if (instruction.StartsWith("nop") || instruction.StartsWith("jmp"))
                {
                    _swapableIndices.Add(index);
                }
            }
        }

        public override string Name => "Handheld Halting";

        public override object SolvePart1() => RunBootCode(0).Accumulator;

        public override object SolvePart2()
        {
            for (int occurrenceToSwap = 1;
                 occurrenceToSwap < _swapableIndices.Count;
                 occurrenceToSwap++)
            {
                var (Accumulator, TerminatedSuccessfully) = RunBootCode(occurrenceToSwap);
                if (TerminatedSuccessfully)
                {
                    return Accumulator;
                }
            }
            throw new MagicSmokeException();
        }

        private (int Accumulator, bool TerminatedSuccessfully) RunBootCode(int swapInstrNumber)
        {
            int nextInstruction = 0;
            int accumulator = 0;
            var GetInstruction = _inputSwapper(swapInstrNumber);

            HashSet<int> visitedInstructions = new HashSet<int>();

            while (!visitedInstructions.Contains(nextInstruction))
            {
                visitedInstructions.Add(nextInstruction);
                (string instr, int arg) = ParseInstruction(GetInstruction(nextInstruction));
                switch (instr)
                {
                    case "acc":
                        accumulator += arg;
                        nextInstruction++;
                        break;
                    case "jmp":
                        nextInstruction += arg;
                        break;
                    case "nop":
                        nextInstruction++;
                        break;
                    default:
                        throw new MagicSmokeException();
                }

                if (nextInstruction >= Input.Length)
                {
                    return (accumulator, true);
                }
            }
            return (accumulator, nextInstruction >= Input.Length);
        }

        private static (string instr, int arg) ParseInstruction(string instruction)
        {
            var parts = instruction.Split(' ');
            string instr = parts[0];
            int arg = int.Parse(parts[1][1..]) * (parts[1][0] == '-' ? -1 : 1);
            return (instr, arg);
        }
    }
}
