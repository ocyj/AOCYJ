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
    }
}
