namespace JJ.Framework.Presentation.Resources.Tests
{
    [TestClass]
    public class CommonTitlesFormatterTests
    {
        [TestMethod]
        public void EntityCount_WithEntityName_ReturnsFormattedString()
        {
            string result = CommonTitlesFormatter.EntityCount("Items");
            Assert.AreEqual("Number of Items", result);
        }

        [TestMethod]
        public void EntityCount_WithSingleCharacter_ReturnsFormattedString()
        {
            string result = CommonTitlesFormatter.EntityCount("X");
            Assert.AreEqual("Number of X", result);
        }

        [TestMethod]
        public void EntityCount_WithLongEntityName_ReturnsFormattedString()
        {
            string result = CommonTitlesFormatter.EntityCount("VeryLongEntityNameForTesting");
            Assert.AreEqual("Number of VeryLongEntityNameForTesting", result);
        }

        [TestMethod]
        public void EntityCount_WithEmptyString_ReturnsFormattedString()
        {
            string result = CommonTitlesFormatter.EntityCount("");
            Assert.AreEqual("Number of ", result);
        }

        [TestMethod]
        public void EntityCount_WithNull_ReturnsFormattedString()
        {
            string result = CommonTitlesFormatter.EntityCount(null);
            Assert.AreEqual("Number of ", result);
        }
    }
}
