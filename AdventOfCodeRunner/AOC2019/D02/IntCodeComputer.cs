using System;
using System.Collections.Generic;

namespace AdventOfCodeRunner.AOC2019.D02
{
    class MagicSmokeException : Exception { }
    enum IntOpCode { ADD = 1, MULT = 2, STOP = 99}
    internal class IntCodeComputer
    {
        int _programCounter;
        readonly int[] _memory;
        readonly int _memorySize;
        readonly Stack<int> _stack;
        public long NumberOfExecutions { get; private set; }
        private static Func<int, int, int> add = (a, b) => a + b;
        private static Func<int, int, int> mult = (a, b) => a * b;

        public IntCodeComputer(int[] memory)
        {
            _stack = new Stack<int>();
            _programCounter = 0;
            _memory = memory;
            _memorySize = _memory.Length;
            NumberOfExecutions = 0;
        }

        public int[] RunToEnd()
        {
            
            while (true)
            {
                IntOpCode opCode = LoadOperation();
                if(opCode == IntOpCode.ADD)
                {
                    DoOperation(add);
                }
                else if(opCode == IntOpCode.MULT)
                {
                    DoOperation(mult);
                }
                else
                {
                    break;
                }
                NumberOfExecutions++;
            }
            return _memory;
        }

            private IntOpCode LoadOperation()
        {
            if(_programCounter < _memorySize)
            {
                var opCode = (IntOpCode)_memory[_programCounter];
                if (opCode != IntOpCode.STOP)
                {
                    _stack.Push(_memory[_programCounter + 3]);
                    _stack.Push(_memory[_programCounter + 2]);
                    _stack.Push(_memory[_programCounter + 1]);
                    _programCounter += 4;
                }
                return opCode;
            }
            else
            {
                throw new MagicSmokeException();
            }
        }

        private int ReadMemory(int pointer)
        {
            if (pointer < _memorySize)
                return _memory[pointer];
            else
                throw new MagicSmokeException();
        }
        private void WriteMemory(int pointer, int value)
        {
            if (pointer < _memorySize)
                _memory[pointer] = value;
            else
                throw new MagicSmokeException();
        }

        private void DoOperation(Func<int, int, int> operation)
        {
            int arg1Position = _stack.Pop();
            int arg2Position = _stack.Pop();
            int resultPosition = _stack.Pop();
            int arg1 = ReadMemory(arg1Position);
            int arg2 = ReadMemory(arg2Position);
            int result = operation(arg1, arg2);
            WriteMemory(resultPosition, result);
        }
    }
}