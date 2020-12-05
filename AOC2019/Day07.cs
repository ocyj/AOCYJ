using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AOC2019.D06;
using Common;
using CommonShared;

namespace AOC2019
{
    class Day07 : Day
    {
        public override int Date => 7;

        public override string Name => "Amplification Circuit";

        private readonly Queue<int> computerIO;

        public Day07()
        {
            computerIO = new Queue<int>();
        }

        public override object SolvePart1()
        {
            int[] program = Input[0].Split(',').Select(s => int.Parse(s)).ToArray();
   
            int maxOutput = int.MinValue;
            int[] phaseSettingsMax = null;
            foreach (var permutatation in (new int[] { 0, 1, 2, 3, 4 }).AllPermutations())
            {
                var computerA = ComputerFactory(program);
                var computerB = ComputerFactory(program);
                var computerC = ComputerFactory(program);
                var computerD = ComputerFactory(program);
                var computerE = ComputerFactory(program);
                computerIO.Clear();
                computerIO.Enqueue(permutatation[0]);
                computerIO.Enqueue(0);
                computerIO.Enqueue(permutatation[1]);
                // P_a, 0, P_b

                computerA.RunToCompletion();
                // P_b, U_a

                computerIO.Enqueue(permutatation[2]);
                // P_b, U_a, P_c

                computerB.RunToCompletion();
                // P_c, U_b

                computerIO.Enqueue(permutatation[3]);
                // P_c, U_b, P_d

                computerC.RunToCompletion();
                // P_d, U_c

                computerIO.Enqueue(permutatation[4]);
                // P_d, U_c, P_e

                computerD.RunToCompletion();
                // P_e, U_d

                computerE.RunToCompletion();
                // U_e

                int output = computerIO.Dequeue();
                if (output > maxOutput)
                {
                    maxOutput = output;
                    phaseSettingsMax = permutatation;
                }
            }
            return $"Maximum output was {maxOutput}";
        }

        private IntCodeComputer ComputerFactory(int[] program)
        {
            return new IntCodeComputer(program)
            {
                ReadInput = () => computerIO.Dequeue(),
                WriteOutput = a => computerIO.Enqueue(a)
            };
        }

        public override object SolvePart2()
        {
            return "";
        }
    }
}
