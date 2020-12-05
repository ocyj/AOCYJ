using System;
using System.Collections.Generic;
using System.Text;
using Common;

using NUnit.Framework;

namespace Common.Test
{
    [TestFixture]
    public class ExtensionsShould
    {

        [Test]
        public void PairExtensionsShouldEnumeratePairs()
        {
            // Arrange
            List<char> inputSequence = new List<char>() { 'A', 'B', 'C', 'D' };

            // Act
            var pairs = inputSequence.Pairs();

            //Assert
            CollectionAssert.AllItemsAreInstancesOfType(pairs, typeof(Pair<char>));
        }

        [TestCase(3, 2, 4, true)]
        [TestCase(2, 2, 4, true)]
        [TestCase(4, 2, 4, true)]
        [TestCase(3, 3, 3, true)]
        [TestCase(2, 3, 5, false)]
        [TestCase(6, 3, 5, false)]
        public void WithinRangeShouldCheckNumbersWithinRangeIncludingByDefault(int number, int lo, int hi, bool result)
        {
            Assert.That(number.WithinRange(lo, hi), Is.EqualTo(result));
        }

        [TestCase("234", true)]
        [TestCase("0000123", true)]
        [TestCase("00r0123", false)]
        [TestCase("00 0123", false)]
        public void OnlyDecimalDigitsShouldVerifyStrings(string s, bool result)
        {
            Assert.That(s.OnlyDecimalDigits(), Is.EqualTo(result));
        }

        [TestCase("234", true)]
        [TestCase("2a4", true)]
        [TestCase("aaa", true)]
        [TestCase("abc", true)]
        [TestCase("def", true)]
        [TestCase("ghi", false)]
        [TestCase(" ab ", false)]
        [TestCase("4", true)]
        [TestCase("a", true)]
        [TestCase("239023AaB", true)]
        [TestCase("2e4", true)]

        public void OnlyHexadecimalDigitsShouldVerifyStringsAndAllowUpperCaseByDefault(string s, bool result)
        {
            Assert.That(s.OnlyHexadecimalDigits(), Is.EqualTo(result));
        }
    }
}
