using System;
using System.Collections.Generic;
using System.Text;

using Common;

using NUnit.Framework;

namespace Common.Test
{
    class IntCodeComputerShould
    {
        [TestCase(new int[] { 1101, 1, 1, 3, 99 }, 2)]
        [TestCase(new int[] { 1101, 2, 2, 3, 99 }, 4)]
        [TestCase(new int[] { 1101, 3, 2, 3, 99 }, 5)]
        public void CalculateOpCode1WithImmediateModeInputAsAdd(int[] memory, int expectedResult)
        {
            // Arrange
            var computer = new IntCodeComputer(memory);

            // Act
            int[] memoryDump = computer.RunToCompletion();

            // Assert
            int[] expectedMemory = memory;
            expectedMemory[3] = expectedResult;
            CollectionAssert.AreEqual(expectedMemory, memoryDump);
        }

        [TestCase(new int[] { 1102, 5, 4, 3, 99 }, 20)]
        [TestCase(new int[] { 1102, 6, 2, 3, 99 }, 12)]
        public void CalculateOpCode2WithImmediateModeInputAsMultiply(int[] memory, int expectedResult)
        {
            // Arrange
            var computer = new IntCodeComputer(memory);

            // Act
            int[] memoryDump = computer.RunToCompletion();

            // Assert
            int[] expectedMemory = (int[])memory.Clone();
            expectedMemory[3] = expectedResult;
            CollectionAssert.AreEqual(expectedMemory, memoryDump);
        }

        [TestCase(new int[] { 1002, 5, 2, 3, 99, 10 }, 20)]
        public void CalculateOpCode2WithOnePositionalModeOneImmediateModeInputAsMultiply(int[] memory, int expectedResult)
        {
            // Arrange
            var computer = new IntCodeComputer(memory);

            // Act
            int[] memoryDump = computer.RunToCompletion();

            // Assert
            int[] expectedMemory = (int[])memory.Clone();
            expectedMemory[3] = expectedResult;
            CollectionAssert.AreEqual(expectedMemory, memoryDump);
        }

        [TestCase(new int[] { 2, 5, 6, 7, 99, 10, 20, 0 }, 200)]
        public void CorrectlyInterpretImplicitZeroesInOpCodePosition(int[] memory, int expectedResult)

        {
            // Arrange
            var computer = new IntCodeComputer(memory);

            // Act
            int[] memoryDump = computer.RunToCompletion();

            // Assert
            Assert.That(memoryDump[7], Is.EqualTo(expectedResult));
        }

        [TestCase(new int[] { 3, 0, 99}, 5)]
        public void ReadInputWithOpCode3(int[] memory, int input)
        {
            // Arrange
            var computer = new IntCodeComputer(memory)
            {
                ReadInput = () => input
            };

            // Act
            int[] memoryDump = computer.RunToCompletion();

            // Assert
            Assert.That(memoryDump[0], Is.EqualTo(input));
        }

        [TestCase(new int[] { 4, 3, 99, 800 }, 800)]
        public void WriteOutputWithOpCode4(int[] memory, int expectedOutput)
        {
            int actualOutput = 0;
            // Arrange
            var computer = new IntCodeComputer(memory)
            {
                WriteOutput = v => actualOutput = v
            };

            // Act
            computer.RunToCompletion();

            // Assert
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase(new int[] { 4, 3, 99, 800 }, 800)]
        [TestCase(new int[] { 104, 3, 99, 800 }, 3)]
        public void UnderstandParameterModeForOutputsAsWell(int[] memory, int expectedOutput)
        {
            // Arrange
            int actualOutput = 0;
            var computer = new IntCodeComputer(memory)
            {
                WriteOutput = v => actualOutput = v
            };

            // Act
            computer.RunToCompletion();

            // Assert
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(10000)]
        [TestCase(42)]
        public void OutPutItsInputWithThisProgram(int value)
        {
            //Arrange
            int actualOutput = int.MinValue;
            var computer = new IntCodeComputer(new[] { 3, 0, 4, 0, 99 })
            {
                ReadInput = () => value,
                WriteOutput = i => actualOutput = i
            };

            // Act
            computer.RunToCompletion();

            // Assert
            Assert.That(value, Is.EqualTo(actualOutput));
        }

        [TestCase(7, 0)]
        [TestCase(8, 1)]
        [TestCase(9, 0)]
        public void ImplementOpCode8AsEqualsWithPositionalMode(int input, int expectedOutput)
        {
            // Arrange
            var program = new[] { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };
            int actualOutput = int.MinValue;
            var computer = new IntCodeComputer(program)
            {
                ReadInput = () => input,
                WriteOutput = v => actualOutput = v
            };

            // Act
            computer.RunToCompletion();

            // Assert
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase(7, 0)]
        [TestCase(8, 1)]
        [TestCase(9, 0)]
        public void ImplementOpCode8AsEqualsAndUseImmediateMode(int input, int expectedOutput)
        {
            // Arrange
            var program = new[] { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };
            int actualOutput = int.MinValue;
            var computer = new IntCodeComputer(program)
            {
                ReadInput = () => input,
                WriteOutput = v => actualOutput = v
            };

            // Act
            computer.RunToCompletion();

            // Assert
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [TestCase(6, 1)]
        [TestCase(7, 1)]
        [TestCase(8, 0)]
        [TestCase(9, 0)]
        public void ImplementOpCode7AsLessThanAndUsePositionalMode(int input, int expectedOutput)
        {
            // Arrange
            var program = new[] { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };
            int actualOutput = int.MinValue;
            var computer = new IntCodeComputer(program)
            {
                ReadInput = () => input,
                WriteOutput = v => actualOutput = v
            };

            // Act
            computer.RunToCompletion();

            // Assert
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));

        }


        [TestCase(6, 1)]
        [TestCase(7, 1)]
        [TestCase(8, 0)]
        [TestCase(9, 0)]
        public void ImplementOpCode7AsLessThanAndUseImmediateMode(int input, int expectedOutput)
        {
            // Arrange
            var program = new[] { 3,3,1107,-1,8,3,4,3,99 };

            int actualOutput = int.MinValue;
            var computer = new IntCodeComputer(program)
            {
                ReadInput = () => input,
                WriteOutput = v => actualOutput = v
            };

            // Act
            computer.RunToCompletion();

            // Assert
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));

        }

    }
}
