using Common;
using CommonShared;
using System;
using System.Collections.Generic;

namespace AOC2020
{
    public class Day08 : DayOf2020
    {
        private List<int> SwapableIndices;
        private Func<int, string> InputSwapper(int swapNth)
        {
            if (swapNth == 0)
            {
                return index => Input[index];
            }
            else
            {
                return index =>
                {
                    if (index == SwapableIndices[swapNth - 1])
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
        public override int Date => 8;

        public override string Name => "Handheld Halting";

        public override object SolvePart1() => RunBootCode(0).Accumulator;

        private (int Accumulator, bool TerminatedSuccessfully) RunBootCode(int swapInstrNumber)
        {
            int nextInstruction = 0;
            int accumulator = 0;
            var GetInstruction = InputSwapper(swapInstrNumber);

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

                if(nextInstruction >= Input.Length)
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

        public override object SolvePart2()
        {
            for(int occurrenceToSwap = 1;
                occurrenceToSwap < SwapableIndices.Count;
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

        internal override void Prepare()
        {
            SwapableIndices = new List<int>();
            for (int index = 0; index < Input.Length; index++)
            {
                string instruction = Input[index];
                if (instruction.StartsWith("nop") || instruction.StartsWith("jmp"))
                {
                    SwapableIndices.Add(index);
                }
            }
        }
    }
}
