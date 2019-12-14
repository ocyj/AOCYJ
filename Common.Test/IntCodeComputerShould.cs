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
    }
}
