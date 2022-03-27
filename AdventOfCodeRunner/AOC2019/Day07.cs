using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCodeRunner.AOC2019.D05;
using AdventOfCodeRunner.Common;

namespace AdventOfCodeRunner.AOC2019
{
    [AdventOfCode(Year = 2019, Day = 7)]
    public class Day07 : Day
    {
        public override string Name => "Amplification Circuit";

        public override object SolvePart1()
        {
            int[] program = Input[0].Split(',').Select(int.Parse).ToArray();

            int maxOutput = int.MinValue;
            foreach (var permutation in (new[] { 0, 1, 2, 3, 4 }).AllPermutations())
            {
                var computerA = new IntCodeComputer(program);
                var computerB = new IntCodeComputer(program);
                var computerC = new IntCodeComputer(program);
                var computerD = new IntCodeComputer(program);
                var computerE = new IntCodeComputer(program);

                bool first = true;
                computerA.ReadInput = () =>
                {
                    if (first)
                    {
                        first = false;
                        return Task.FromResult(permutation[0]);
                    }
                    return Task.FromResult(0);
                };

                var cnxAToB = new Connection(permutation[1]);
                computerA.WriteOutput = cnxAToB.PutValue;
                computerB.ReadInput = cnxAToB.PullValue;

                var cnxBToC = new Connection(permutation[2]);
                computerB.WriteOutput = cnxBToC.PutValue;
                computerC.ReadInput = cnxBToC.PullValue;

                var cnxCToD = new Connection(permutation[3]);
                computerC.WriteOutput = cnxCToD.PutValue;
                computerD.ReadInput = cnxCToD.PullValue;

                var cnxDToE = new Connection(permutation[4]);
                computerD.WriteOutput = cnxDToE.PutValue;
                computerE.ReadInput = cnxDToE.PullValue;

                var thrusterSignal = int.MinValue;
                computerE.WriteOutput = (output) => thrusterSignal = output;

                var taskA = computerA.RunToCompletion();
                var taskB = computerB.RunToCompletion();
                var taskC = computerC.RunToCompletion();
                var taskD = computerD.RunToCompletion();
                var taskE = computerE.RunToCompletion();

                Task.WhenAll(taskA, taskB, taskC, taskD, taskE);

                if (thrusterSignal > maxOutput)
                {
                    maxOutput = thrusterSignal;
                }
            }
            return $"Maximum output was {maxOutput}";
        }

        public override object SolvePart2()
        {
            int[] program = Input[0].Split(',').Select(int.Parse).ToArray();

            var maxOutput = int.MinValue;
            foreach (int[] permutation in (new[] { 5, 6, 7, 8, 9 }).AllPermutations())
            {
                var cnxAToB = new Connection(permutation[1]);
                var cnxBToC = new Connection(permutation[2]);
                var cnxCToD = new Connection(permutation[3]);
                var cnxDToE = new Connection(permutation[4]);
                var cnxEToA = new Connection(new[] { permutation[0], 0 });

                var computerA = new IntCodeComputer(program)
                {
                    ReadInput = cnxEToA.PullValue,
                    WriteOutput = cnxAToB.PutValue,

                };
                var computerB = new IntCodeComputer(program)
                {
                    ReadInput = cnxAToB.PullValue,
                    WriteOutput = cnxBToC.PutValue
                };
                var computerC = new IntCodeComputer(program)
                {
                    ReadInput = cnxBToC.PullValue,
                    WriteOutput = cnxCToD.PutValue
                };
                var computerD = new IntCodeComputer(program)
                {
                    ReadInput = cnxCToD.PullValue,
                    WriteOutput = cnxDToE.PutValue
                };
                var computerE = new IntCodeComputer(program)
                {
                    ReadInput = cnxDToE.PullValue,
                    WriteOutput = cnxEToA.PutValue
                };

                var taskA = computerA.RunToCompletion();
                var taskB = computerB.RunToCompletion();
                var taskC = computerC.RunToCompletion();
                var taskD = computerD.RunToCompletion();
                var taskE = computerE.RunToCompletion();

                Task.WhenAll(taskA, taskB, taskC, taskD, taskE);

                var thrusterSignal = cnxEToA.PullValue().Result;
                if (thrusterSignal > maxOutput)
                {
                    maxOutput = thrusterSignal;
                }
            }
            return $"Maximum output was {maxOutput}";
        }

        public Day07(string[] input) : base(input) { }
    }

    internal class Connection
    {
        private readonly Queue<int> _valueBuffer;
        private TaskCompletionSource _ioOperationTaskCompletionSource;

        public Connection(int initialValue) : this(new [] {initialValue}) { }
        public Connection(IEnumerable<int> initialValues)
        {
            _valueBuffer = new();
            foreach (var value in initialValues)
            {
                _valueBuffer.Enqueue(value);
            }

            if (!_valueBuffer.Any())
            {
                _ioOperationTaskCompletionSource = new();
            }
        }

        public void PutValue(int value)
        {
            _valueBuffer.Enqueue(value);
            _ioOperationTaskCompletionSource?.SetResult();
        }

        public async Task<int> PullValue()
        {
            if (_ioOperationTaskCompletionSource != null)
            {
                await _ioOperationTaskCompletionSource.Task;
            }

            var value = _valueBuffer.Dequeue();
            if (!_valueBuffer.Any())
            {
                _ioOperationTaskCompletionSource = new();
            }
            return value;
        }
    }
}
