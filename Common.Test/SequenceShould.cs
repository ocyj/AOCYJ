using System.Collections.Generic;
using NUnit.Framework;
using Common;

namespace Common.Test
{
    public class SequenceShould
    {
        [SetUp]
        public void Setup() { }

        [TestCase(0, 4, new[] { 0,1,2,3 })]
        [TestCase(1, 4, new[] { 1,2,3 })]
        [TestCase(2, 4, new[] { 2,3 })]
        [TestCase(3, 4, new[] { 3 })]
        [TestCase(4, 4, new int[] { })]
        [TestCase(-5, -1, new[] { -5,-4,-3,-2})]
        [TestCase(-3, 4, new[] { -3,-2, -1, 0, 1, 2, 3})]
        public void GenerateValueInIncreasingRangeWithDefaultStep1(int start, int stop, int[] expectedSequence)
        {
            // Arrange
            Sequence sut = new Sequence(start, stop);

            // Act
            List<int> rangeReturned = new List<int>();
            foreach(int i in sut)
            {
                rangeReturned.Add(i);
            }

            // Assert
            Assert.That(rangeReturned, Has.Count.EqualTo(expectedSequence.Length));
            CollectionAssert.AreEqual(expectedSequence, rangeReturned);
        }

        [TestCase(4, 0, new[] { 4, 3, 2, 1})]
        [TestCase(4, -1, new[] { 4, 3, 2, 1, 0})]
        [TestCase(0, -3, new[] { 0, -1, -2})]
        [TestCase(-1, -3, new[] { -1, -2})]
        public void GenerateValueInDecreasingRangeWithStepNegative1(int start, int stop, int[] expectedSequence)
        {
            // Arrange
            Sequence sut = new Sequence(start, stop, -1);

            // Act
            List<int> rangeReturned = new List<int>();
            foreach (int i in sut)
            {
                rangeReturned.Add(i);
            }

            // Assert
            Assert.That(rangeReturned, Has.Count.EqualTo(expectedSequence.Length));
            CollectionAssert.AreEqual(expectedSequence, rangeReturned);
        }
    }
}