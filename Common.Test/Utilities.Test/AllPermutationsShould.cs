using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeRunner.Common;

namespace Common.Test.Utilities.Test
{
    class AllPermutationsShould
    {
        [Test]
        public void Give2PermutationsOfArrayOfLenghth2()
        {
            // Arrange
            int[] input = new[] { 1, 2 };

            // Act
            var output = input.AllPermutations();

            // Assert
            Assert.That(output.Count(), Is.EqualTo(2));
            CollectionAssert.Contains(output, new[] { 1, 2 });
            CollectionAssert.Contains(output, new[] { 2, 1 });
        }

        [Test]
        public void PermutationsOfInputGiveSameOutput()
        {
            // Arrange
            int[] input1 = new[] { 1, 2 };
            int[] input2 = new[] { 2, 1 };
            var expectedOutput = new List<int[]>() { new[] { 1, 2 }, new[] { 2, 1 } };

            // Act
            var output1 = input1.AllPermutations();
            var output2 = input2.AllPermutations();

            // Assert
            CollectionAssert.AreEquivalent(expectedOutput, output1);
            CollectionAssert.AreEquivalent(expectedOutput, output2);
        }

        [Test]
        public void Give6CorrectPermutationsOfArrayOfLenghth3()
        {
            // Arrange
            int[] input = new[] { 1, 2, 3 };

            // Act
            var output = input.AllPermutations();

            // Assert
            Assert.That(output.Count(), Is.EqualTo(6));
            CollectionAssert.Contains(output, new[] { 1, 2, 3 });
            CollectionAssert.Contains(output, new[] { 1, 3, 2 });
            CollectionAssert.Contains(output, new[] { 2, 1, 3 });
            CollectionAssert.Contains(output, new[] { 2, 3, 1 });
            CollectionAssert.Contains(output, new[] { 3, 2, 1 });
            CollectionAssert.Contains(output, new[] { 3, 1, 2 });
        }
    }
}
