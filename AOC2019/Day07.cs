using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOC2019.D06;
using Common;
using CommonShared;

namespace AOC2019
{
    public class Day07 : DayOf2019
    {
        public override int Date => 7;

        public override string Name => "Amplification Circuit";

        public override object SolvePart1()
        {
            int[] program = Input[0].Split(',').Select(s => int.Parse(s)).ToArray();

            int maxOutput = int.MinValue;
            int[] phaseSettingsMax = null;
            foreach (var permutatation in (new int[] { 0, 1, 2, 3, 4 }).AllPermutations())
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
                        return Task.FromResult(permutatation[0]);
                    }
                    else return Task.FromResult(0);
                };

                var cnxAB = new Connection(permutatation[1]);
                computerA.WriteOutput = cnxAB.WriteValue;
                computerB.ReadInput = cnxAB.ReadValue;

                var cnxBC = new Connection(permutatation[2]);
                computerB.WriteOutput = cnxBC.WriteValue;
                computerC.ReadInput = cnxBC.ReadValue;

                var cnxCD = new Connection(permutatation[3]);
                computerC.WriteOutput = cnxCD.WriteValue;
                computerD.ReadInput = cnxCD.ReadValue;

                var cnxDE = new Connection(permutatation[4]);
                computerD.WriteOutput = cnxDE.WriteValue;
                computerE.ReadInput = cnxDE.ReadValue;


                int thrusterSignal = int.MinValue;
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
                    phaseSettingsMax = permutatation;
                }
            }
            return $"Maximum output was {maxOutput}";
        }

        public override object SolvePart2()
        {
            return "";
        }
    }

    internal class Connection
    {
        private readonly Task _setTask;
        private int _firstInput;
        private int _value;
        private TaskCompletionSource setResultTcs;
        private bool _firstInputDone = false;

        public int Value => _value;

        public Connection(int firstInput)
        {
            setResultTcs = new TaskCompletionSource();
            _setTask = setResultTcs.Task;
            _firstInput = firstInput;

        }

        public void WriteValue(int value)
        {
            _value = value;
            setResultTcs.SetResult();
        }

        public async Task<int> ReadValue()
        {
            if (!_firstInputDone)
            {
                _firstInputDone = true;
                return _firstInput;
            }

            await _setTask;
            return _value;
        }
    }
}
