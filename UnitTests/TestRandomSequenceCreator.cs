using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomNumberSequence.Libraries;
using System;
using System.Linq;

namespace RandomNumberSequence.UnitTests
{
    [TestClass]
    public class TestRandomSequenceCreator
    {
        [TestMethod]
        public void Contains_Numbers_In_Range_And_Only_In_Range()
        {
            var randomSequenceCreator = new RandomSequenceCreator(10000);
            var randomList = randomSequenceCreator.GenerateRandomList();
            var numbersOrdered = Enumerable.Range(1, 10000).ToList();

            var firstNotSecond = numbersOrdered.Except(randomList).ToList();
            var secondNotFirst = randomList.Except(numbersOrdered).ToList();

            Assert.AreEqual(randomList.Count, 10000, "Size of random list is incorrect");
            Assert.IsTrue(firstNotSecond.Count == 0, "Random list does not contain all numbers in the specified range");
            Assert.IsTrue(secondNotFirst.Count == 0, "Random list contains numbers outside the specified range");
        }

        [TestMethod]
        public void Sequence_Is_Unique()
        {
            var randomSequenceCreator = new RandomSequenceCreator(10000);
            var randomList1 = randomSequenceCreator.GenerateRandomList();
            var randomList2 = randomSequenceCreator.GenerateRandomList();

            Assert.IsFalse(randomList1.SequenceEqual(randomList2), "Sequences are the same");
        }

        [TestMethod]
        public void Test_Invalid_Values()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new RandomSequenceCreator(-1));
        }
    }
}
