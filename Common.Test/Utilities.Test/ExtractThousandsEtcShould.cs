using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Common.Test.Utilities.Test
{
    class ExtractThousandsEtcShould
    {
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(1, 0, 0, 0, 1)]
        [TestCase(5, 0, 0, 0, 5)]
        [TestCase(10, 0, 0, 1, 0)]
        [TestCase(11, 0, 0, 1, 1)]
        [TestCase(100, 0, 1, 0, 0)]
        [TestCase(101, 0, 1, 0, 1)]
        [TestCase(111, 0, 1, 1, 1)]
        [TestCase(1000, 1, 0, 0, 0)]
        [TestCase(1111, 1, 1, 1, 1)]
        [TestCase(1010, 1, 0, 1, 0)]
        [TestCase(1002, 1, 0, 0, 2)]
        [TestCase(9999, 9, 9, 9, 9)]
        [TestCase(999, 0, 9, 9, 9)]
        [TestCase(99, 0, 0, 9, 9)]
        public void ReturnCorrectValuesForInputsLessThan9999(int input, int thousands, int hundreds, int tens, int ones)
        {
            var (Thousands, Hundreds, Tens, Ones) = input.ExtractThousandsHundredsTensAndOnes();

            Assert.That(Thousands, Is.EqualTo(thousands));
            Assert.That(Hundreds, Is.EqualTo(hundreds));
            Assert.That(Tens, Is.EqualTo(tens));
            Assert.That(Ones, Is.EqualTo(ones));
        }

        [TestCase(-1)]
        [TestCase(10_000)]
        public void ThrowExceptionsForIntsOutOfRange(int input)
        {
            Assert.That(() => input.ExtractThousandsHundredsTensAndOnes(), Throws.ArgumentException);

        }
    }
}
