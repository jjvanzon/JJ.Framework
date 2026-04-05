using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Mathematics.Tests
{
    [TestClass]
    public class RandomizerCoreTests
    {
        [TestMethod]
        public void GetInt32_WithoutParameters_ReturnsValueInFullRangeExceptMaxValue()
        {
            int value = Randomizer.GetInt32();

            Assert.IsTrue(value >= int.MinValue);
            Assert.IsTrue(value <= int.MaxValue - 1);
        }

        [TestMethod]
        public void GetInt32_WithMax_ReturnsValueInRangeIncludingMax()
        {
            int max = 10;

            int value = Randomizer.GetInt32(max);

            Assert.IsTrue(value >= 0);
            Assert.IsTrue(value <= max);
        }

        [TestMethod]
        public void GetInt32_WithMinAndMax_ReturnsValueInInclusiveRange()
        {
            int min = -5;
            int max = 5;

            int value = Randomizer.GetInt32(min, max);

            Assert.IsTrue(value >= min);
            Assert.IsTrue(value <= max);
        }

        [TestMethod]
        public void GetInt32_WithInt32MaxValue_ThrowsOverflowException()
        {
            Assert.ThrowsException<OverflowException>(() => Randomizer.GetInt32(0, int.MaxValue));
        }

        [TestMethod]
        public void GetRandomItem_WithEmptyCollection_ThrowsException()
        {
            int[] items = Array.Empty<int>();

            Assert.ThrowsException<Exception>(() => Randomizer.GetRandomItem(items));
        }

        [TestMethod]
        public void GetRandomItem_WithSingleItem_ReturnsThatItem()
        {
            int[] items = { 123 };

            int value = Randomizer.GetRandomItem(items);

            Assert.AreEqual(123, value);
        }

        [TestMethod]
        public void GetRandomItem_WithMultipleItems_ReturnsItemFromCollection()
        {
            int[] items = { 10, 20, 30, 40 };

            int value = Randomizer.GetRandomItem(items);

            Assert.IsTrue(items.Contains(value));
        }
    }
}
