using System;
using System.Linq;

namespace Common
{
    public class IntCodeComputer
    {
        private enum ParameterMode { Positional = 0, Immediate = 1 };
        private enum Operation { ADD = 1, MULT = 2, IN = 3, OUT = 4, STOP = 99 };

        readonly int[] _memory;
        int _programCounter;
        public Func<int> ReadInput { get; set; }
        public Action<int> WriteOutput { get; set; }

        public IntCodeComputer(int[] memory)
        {
            _memory = (int[])memory.Clone();
            _programCounter = 0;
        }

        private int ParameterArgument(int i) => _memory[_programCounter + i];

        public int[] MemoryDump => (int[])_memory.Clone();

        public int[] RunToCompletion()
        {
            while (true)
            {
                var operation = ReadOperation();
                if (operation == Operation.ADD || operation == Operation.MULT)
                {
                    var (param1, param2) = LoadParameters();
                    Func<int, int, int> op = operation switch
                    {
                        Operation.ADD => (a, b) => a + b,
                        Operation.MULT => (a, b) => a * b,
                        _ => throw new MagicSmokeException(),
                    };

                    void result(int r) => _memory[_memory[_programCounter + 3]] = r;
                    result(op(param1(), param2()));
                    _programCounter += 4;
                }
                else if (operation == Operation.IN)
                {
                    _memory[_memory[_programCounter + 1]] = ReadInput();
                    _programCounter += 2;
                }
                else if (operation == Operation.OUT)
                {
                    WriteOutput(_memory[_memory[_programCounter + 1]]);
                    _programCounter += 2;
                }
                else if (operation == Operation.STOP)
                {
                    break;
                }
            }
            return MemoryDump;
        }
        private Operation ReadOperation()
        {
            int instruction = _memory[_programCounter];
            var (_, _, Tens, Ones) = instruction.ExtractThousandsHundredsTensAndOnes();
            return (Operation)(Tens * 10 + Ones);
        }
        private (Func<int> param1, Func<int> param2) LoadParameters()
        {
            int instruction = _memory[_programCounter];
            var (p2Mode, p1Mode, _, _) = instruction.ExtractThousandsHundredsTensAndOnes();

            return
                (
                    LoadParameter((ParameterMode)p1Mode, ParameterArgument(1)),
                    LoadParameter((ParameterMode)p2Mode, ParameterArgument(2))
                );
        }

        private Func<int> LoadParameter(ParameterMode parameterMode, int parameterArg)
        {
            return parameterMode switch
            {
                ParameterMode.Positional => () => _memory[parameterArg],
                ParameterMode.Immediate => () => parameterArg,
                _ => throw new MagicSmokeException(),
            };
        }
    }
}
