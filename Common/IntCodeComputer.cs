using System;

namespace Common
{
    public class IntCodeComputer
    {
        private enum ParameterMode { Positional= 0, Immediate = 1 };
        private enum Operation { ADD = 1, MULT = 2, STOP = 99 };

        readonly int[] _memory;
        int _programCounter;

        private void ArithmeticOperation(Func<int> p1, Func<int> p2, Action<int> res, Func<int,int,int> operation)
        {
            res(operation(p1(), p2()));
            _programCounter += 4;
        }

        public IntCodeComputer(int[] memory)
        {
            _memory = (int[])memory.Clone();
            _programCounter = 0;
        }

        void Result(int r) => _memory[_programCounter + 3] = r;
        private int ParameterArgument(int i) => _memory[_programCounter + i];

        public int[] MemoryDump => (int[])_memory.Clone();

        public int[] RunToCompletion()
        {
            string instruction = _memory[_programCounter].ToString();
            var operation = (Operation)int.Parse(instruction[^2..]);
            string parameterModes = instruction[0..^2];

            ParameterMode param1Mode = (ParameterMode)int.Parse(parameterModes[^1].ToString());
            ParameterMode param2Mode = (ParameterMode)int.Parse(parameterModes[^2].ToString());

            var parameter1 = LoadParameter(param1Mode, ParameterArgument(1));
            var parameter2 = LoadParameter(param2Mode, ParameterArgument(2));


            Func<int, int, int> op = operation switch
            {
                Operation.ADD => (a, b) => a + b,
                Operation.MULT => (a, b) => a * b,
                _ => throw new MagicSmokeException(),
            };

            ArithmeticOperation(parameter1, parameter2, Result, op);

            return MemoryDump;
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
